/* HTTP Raw Trace Listener
 * Author: Jonathan Hilgeman <jhilgeman@gmail.com>
 * Last Updated: 2019-06-11
 * 
 * This class uses reflection to hook into the System.Net tracing and then
 * parses out the raw request and response data and passes the data back
 * to any event subscribers.
 * 
 * Usage:
 * System.Diagnostics.HttpRawTraceListener.Initialize();
 * System.Diagnostics.HttpRawTraceListener.FinishedCommunication += HttpRawTraceListener_FinishedCommunication;
 * 
 * private void HttpRawTraceListener_FinishedCommunication(object sender, System.Diagnostics.CommunicationEventArgs e)
 * {
 *     // And here's the request/response.
 *     Console.WriteLine("Raw Request: " + e.Communication.RequestString);
 *     Console.WriteLine("Raw Response: " + e.Communication.ResponseString);
 * }
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Diagnostics
{
    public class HttpRawTraceListener : TraceListener
    {
        /// <summary>
        /// Whether or not to automatically decompress HTTP request / response bodies that are gzipped
        /// </summary>
        public static bool AutomaticDecompression { get; set; } = true;

        /// <summary>
        /// Don't auto-decompress if the compressed content is over this size limit
        /// </summary>
        public static int AutomaticDecompressionSizeLimit { get; set; } = 4194304; // Only auto-decompress if the compressed data is under 4 Mb

        /// <summary>
        /// Event to subscribe to that will fire off the completed communication containing the processed request/response
        /// </summary>
        public static event EventHandler<CommunicationEventArgs> FinishedCommunication;

        private Dictionary<int, Communication> _Communications = new Dictionary<int, Communication>();
        private static object syncRoot = new object();

        // Singleton
        private static HttpRawTraceListener _Instance;
        public static HttpRawTraceListener Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HttpRawTraceListener();
                }
                return _Instance;
            }
        }

        private HttpRawTraceListener() : base("System.Net")
        {
        }

        public static void Initialize()
        {
            // Enable tracing
            Instance.enableTracing();

            // Enable cleanup thread
            Instance.enableCleanupThread();

        }

        /// <summary>
        /// This starts a thread that loops indefinitely, running once a minute and removing
        /// any communications that have ended over a certain # of minutes ago.
        /// </summary>
        private void enableCleanupThread()
        {
            var t = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    // Remove communications that have ended over 5 minutes ago (gives a slight window to review past communications)
                    DateTime dtRemoveThreshold = DateTime.Now.Subtract(new TimeSpan(0, 5, 0));

                    lock (syncRoot)
                    {
                        // Find all communications that completed over 5 minutes ago
                        var removeComm = _Communications.Where(c => c.Value.CurrentState == Communication.State.MarkedForCleanup && ((DateTime)c.Value.Ended < dtRemoveThreshold)).ToList();
                        foreach (var kv in removeComm)
                        {
                            _Communications.Remove(kv.Key);
                        }
                    }

                    // Run once a minute
                    System.Threading.Thread.Sleep(60000);
                }
            });
            t.Start();
        }

        /// <summary>
        /// This uses reflection to enable the tracing/logging that is normally enabled via an app.config
        /// configuration file, and use this custom listener to receive the messages.
        /// </summary>
        private void enableTracing()
        {
            // Enable logging on System.Net
            var loggingType = typeof(System.Net.Sockets.Socket).Assembly.GetType("System.Net.Logging");

            // If needed, trigger the logging initialiation with a dummy web request
            var privateStaticFlags = (BindingFlags.NonPublic | BindingFlags.Static);
            var fieldLoggingInitialized = loggingType.GetField("s_LoggingInitialized", privateStaticFlags);
            if ((bool)fieldLoggingInitialized.GetValue(null) == false)
            {
                // Dummy web request
                System.Net.WebRequest.Create("http://localhost");

                // Wait for the initialization
                var t = new System.Threading.Thread(() =>
                {
                    while (!(bool)fieldLoggingInitialized.GetValue(null))
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                });
                t.Start();

                // Block until thread completed
                t.Join();
            }

            // Turn on the LoggingEnabled private static flag
            loggingType.GetField("s_LoggingEnabled", privateStaticFlags).SetValue(null, true);

            // Get the "Web" TraceSource (only available after initialization completes - otherwise is null)
            var webProperty = loggingType.GetProperty("Web", privateStaticFlags);
            var tsWeb = (TraceSource)webProperty.GetValue(null, null);

            // Flip the switch and make sure autoflushing is enabled
            tsWeb.Switch.Level = SourceLevels.Verbose;
            Trace.AutoFlush = true;

            // And finally, attach our little listener
            tsWeb.Listeners.Add(Instance);
        }

        /// <summary>
        /// We only care about WriteLine
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message) { }

        /// <summary>
        /// Process a message
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            try
            {
                // Get the thread ID
                int threadID = getThreadID(message);

                // Find the corresponding Communication object, creating if necessary
                Communication comm = null;
                lock (syncRoot)
                {
                    if (!_Communications.ContainsKey(threadID))
                    {
                        _Communications.Add(threadID, new Communication(threadID));
                    }
                    comm = _Communications[threadID];
                }

                // Now let the Communications object process the message
                if (comm.ProcessMessage(message))
                {
                    FinishedCommunication?.Invoke(this, new CommunicationEventArgs(comm));

                    // Remove once finished
                    lock (syncRoot)
                    {
                        comm.MarkForCleanup();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\nTrace Message = " + message);
            }
        }

        /// <summary>
        /// Attempt to extract the thread ID from the message
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Thread ID, if successful, otherwise -1 if there's an error or no thread ID found</returns>
        private int getThreadID(string message)
        {
            try
            {
                int pos1 = message.IndexOf("[");
                if (pos1 == -1) { return -1; }
                pos1++;
                int pos2 = message.IndexOf(']', pos1);
                return int.Parse(message.Substring(pos1, pos2 - pos1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Communication
    {
        public int ThreadID;
        public DateTime Started;
        public DateTime? Ended;
        public double TotalMilliseconds
        {
            get
            {
                if (Ended == null) { return -1; }
                return ((DateTime)Ended - Started).TotalMilliseconds;
            }
        }

        public Dictionary<string, KeyValuePair<string, string>> HTTPRequestHeadersDictionary = new Dictionary<string, KeyValuePair<string, string>>();
        public string HTTPRequestLine;
        public string HTTPRequestHeaders;
        public byte[] HTTPRequestBody;
        public string HTTPRequestContentType;
        public Encoding HTTPRequestEncoding;


        public Dictionary<string, KeyValuePair<string, string>> HTTPResponseHeadersDictionary = new Dictionary<string, KeyValuePair<string, string>>();
        public string HTTPResponseHeaders;
        public byte[] HTTPResponseBody;
        public string HTTPResponseContentType;
        public Encoding HTTPResponseEncoding;

        public string HTTPRequestBodyString
        {
            get
            {
                if (HTTPRequestBody == null) { return ""; }

                // Note that this ASSUMES the data is UTF-8. If the data is something like binary data or ASCII or some other encoding, this will cause problems.
                return HTTPRequestEncoding.GetString(HTTPRequestBody);
            }
        }
        public string HTTPResponseBodyString
        {
            get
            {
                if (HTTPResponseBody == null) { return ""; }

                // Note that this ASSUMES the data is UTF-8. If the data is something like binary data or ASCII or some other encoding, this will cause problems.
                return HTTPResponseEncoding.GetString(HTTPResponseBody);
            }
        }




        public string RequestString
        {
            get
            {
                string headers = HTTPRequestHeaders;
                string body = HTTPRequestBodyString;
                return new StringBuilder(HTTPRequestLine.Length + headers.Length + body.Length + 8)
                    .AppendLine(HTTPRequestLine)
                    .AppendLine(headers)
                    .AppendLine()
                    .AppendLine(body)
                    .ToString();
            }
        }
        public string ResponseString
        {
            get
            {
                string headers = HTTPResponseHeaders;
                string body = HTTPResponseBodyString;
                return new StringBuilder(headers.Length + body.Length + 6)
                  .AppendLine(headers)
                  .AppendLine()
                  .AppendLine(body)
                  .ToString();
            }
        }

        public State CurrentState;
        public enum State
        {
            WaitingForRequest,
            WaitingForRequestHeaders,
            WaitingForRequestData,
            CollectingRequestData,
            WaitingForResponseHeaders,
            WaitingForResponseData,
            CollectingResponseData,
            Completed,
            MarkedForCleanup
        }

        /// <summary>
        /// Temporary aggregator of hex data 
        /// </summary>
        public StringBuilder sbHexDataBytes;

        public static Regex reMatchRequestLine = new Regex("\\] HttpWebRequest#[0-9]+ - Request: (.*)", RegexOptions.Compiled);
        public static Regex reMatchRequestHeaders = new Regex("\\] ConnectStream#[0-9]+ - Sending headers(.*)", RegexOptions.Compiled | RegexOptions.Singleline);
        public static Regex reMatchRequestDataStart = new Regex("\\] Data from ConnectStream#[0-9]+::Write", RegexOptions.Compiled);
        public static Regex reMatchData = new Regex("\\] [0-9A-Fa-f]{8} : ([0-9A-Fa-f\\-\\s]+)", RegexOptions.Compiled);
        public static Regex reMatchResponseHeaders = new Regex("\\] Connection#[0-9]+ - Received headers(.*)", RegexOptions.Compiled | RegexOptions.Singleline);
        public static Regex reMatchResponseDataStart = new Regex("\\] Data from ConnectStream#[0-9]+::Read", RegexOptions.Compiled);

        /// <summary>
        /// Initialize new Communication object
        /// </summary>
        /// <param name="threadID"></param>
        public Communication(int threadID)
        {
            ThreadID = threadID;
            // Started = DateTime.Now;
            sbHexDataBytes = new StringBuilder();
            CurrentState = State.WaitingForRequest;
        }

        public void MarkForCleanup()
        {
            /*
            HTTPRequestLine = null;
            HTTPRequestHeaders = null;
            HTTPRequestBody = null;
            HTTPResponseHeaders = null;
            HTTPResponseBody = null;
            */
            CurrentState = State.MarkedForCleanup;
        }

        /// <summary>
        /// Take the accumulated hex data and process it into a UTF-8 string
        /// </summary>
        /// <returns></returns>
        private byte[] HexDataToBytes()
        {
            // Get the hex data without spaces or dashes and reset the StringBuilder
            string hex = sbHexDataBytes.Replace(" ", "").Replace("-", "").ToString().Trim();
            sbHexDataBytes.Clear();

            int charCount = hex.Length;
            byte[] bytes = new byte[charCount / 2];
            for (int i = 0; i < charCount; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return bytes;
        }

        /// <summary>
        /// Process a tracing line, looking for data to record and any state changes
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ProcessMessage(string message)
        {
            if ((CurrentState == State.WaitingForRequest) || (CurrentState == State.MarkedForCleanup)) // Watch for MarkedForCleanup state in the rare instance that the same thread ID is reused before the communication is removed
            {
                var match = reMatchRequestLine.Match(message);
                if (match.Success)
                {
                    Started = DateTime.Now;
                    string s = match.Groups[1].Value;
                    HTTPRequestLine = s.Trim();
                    CurrentState = State.WaitingForRequestHeaders;
                }
            }
            else if (CurrentState == State.WaitingForRequestHeaders)
            {
                var match = reMatchRequestHeaders.Match(message);
                if (match.Success)
                {
                    string s = match.Groups[1].Value;
                    s = s.TrimStart('{', '\r', '\n').TrimEnd('.').TrimEnd('}').TrimEnd();
                    HTTPRequestHeaders = s;
                    CurrentState = State.WaitingForRequestData;
                }
            }
            else if (CurrentState == State.WaitingForRequestData)
            {
                if (reMatchRequestDataStart.IsMatch(message))
                {
                    CurrentState = State.CollectingRequestData;
                }
                else if (reMatchResponseHeaders.IsMatch(message))
                {
                    CurrentState = State.WaitingForResponseHeaders;
                }
            }
            else if (CurrentState == State.CollectingRequestData)
            {
                var match = reMatchData.Match(message);
                if (match.Success)
                {
                    string s = match.Groups[1].Value;
                    sbHexDataBytes.Append(s);
                }
                else
                {
                    byte[] s = HexDataToBytes();
                    HTTPRequestBody = s;
                    CurrentState = State.WaitingForResponseHeaders;
                }
            }


            if (CurrentState == State.WaitingForResponseHeaders)
            {
                var match = reMatchResponseHeaders.Match(message);
                if (match.Success)
                {
                    // We got a response - end the timer
                    Ended = DateTime.Now;

                    string s = match.Groups[1].Value;
                    s = s.TrimStart('{', '\r', '\n').TrimEnd('.').TrimEnd('}').TrimEnd();
                    HTTPResponseHeaders = s;
                    CurrentState = State.WaitingForResponseData;
                }
            }
            else if (CurrentState == State.WaitingForResponseData)
            {
                if (reMatchResponseDataStart.IsMatch(message))
                {
                    CurrentState = State.CollectingResponseData;
                }
            }
            else if (CurrentState == State.CollectingResponseData)
            {
                var match = reMatchData.Match(message);
                if (match.Success)
                {
                    string s = match.Groups[1].Value;
                    sbHexDataBytes.Append(s);
                }
                else
                {
                    byte[] s = HexDataToBytes();
                    HTTPResponseBody = s;
                    CurrentState = State.Completed;

                    // Finished, return true
                    postCompletionHook();
                    return true;
                }
            }

            // Not finished yet
            return false;
        }

        /// <summary>
        /// After all the required pieces are collected, this method runs to parse / process what's been collected
        /// </summary>
        private void postCompletionHook()
        {
            // Parse request and response headers
            HTTPRequestHeadersDictionary = parseHeaders(HTTPRequestHeaders);
            HTTPResponseHeadersDictionary = parseHeaders(HTTPResponseHeaders);

            // Determine content type and encoding
            tryDetermineContentTypeAndEncoding(HTTPRequestHeadersDictionary, out HTTPRequestContentType, out HTTPRequestEncoding);
            tryDetermineContentTypeAndEncoding(HTTPResponseHeadersDictionary, out HTTPResponseContentType, out HTTPResponseEncoding);

            // Automatic decompression of Gzip-compressed requests/responses (enabled by default)
            if (HttpRawTraceListener.AutomaticDecompression)
            {
                if (HTTPRequestHeadersDictionary.ContainsKey("content-encoding") && (HTTPRequestHeadersDictionary["content-encoding"].Value == "gzip"))
                {
                    if (HTTPRequestBody.Length <= HttpRawTraceListener.AutomaticDecompressionSizeLimit)
                    {
                        HTTPRequestBody = decompressGzip(HTTPRequestBody);
                    }
                }
                if (HTTPResponseHeadersDictionary.ContainsKey("content-encoding") && (HTTPResponseHeadersDictionary["content-encoding"].Value == "gzip"))
                {
                    if (HTTPResponseBody.Length <= HttpRawTraceListener.AutomaticDecompressionSizeLimit)
                    {
                        HTTPResponseBody = decompressGzip(HTTPResponseBody);
                    }
                }
            }
        }

        /// <summary>
        /// Tries to check the Content-Type HTTP header, if it exists, to see if we can parse it out
        /// and store it separately, along with determining the character set / encoding.
        /// </summary>
        /// <param name="headersDictionary"></param>
        /// <param name="contentType"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private bool tryDetermineContentTypeAndEncoding(Dictionary<string, KeyValuePair<string, string>> headersDictionary, out string contentType, out Encoding encoding)
        {
            contentType = null;
            encoding = Encoding.ASCII; // Default to ASCII if there's no encoding at all
            if (headersDictionary.ContainsKey("content-type"))
            {
                string[] pieces = headersDictionary["content-type"].Value.Split(';');
                contentType = pieces[0].Trim();
                if (pieces.Length > 1)
                {
                    if (pieces[1].IndexOf("charset") >= 0)
                    {
                        string[] encodingPieces = pieces[1].Split('=');
                        if (encodingPieces.Length > 1)
                        {
                            string rawEncoding = encodingPieces[1].Trim().ToLower();
                            try
                            {
                                encoding = Encoding.GetEncoding(rawEncoding);
                            }
                            catch (Exception)
                            {
                                // Default to UTF-8 if there's a charset specified but the GetEncoding() call fails
                                encoding = Encoding.UTF8;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Reads the header, line-by-line, and parses those values out into a dictionary, where
        /// the key is a lower-case HTTP header key, and the value is the raw HTTP key/value pair
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        private Dictionary<string, KeyValuePair<string, string>> parseHeaders(string headers)
        {
            Dictionary<string, KeyValuePair<string, string>> result = new Dictionary<string, KeyValuePair<string, string>>();
            using (IO.StringReader sr = new IO.StringReader(headers))
            {
                string line;
                var delim = new char[] { ':' };
                while ((line = sr.ReadLine()) != null)
                {
                    string[] pieces = line.Split(delim, 2);
                    string lcKey = pieces[0].Trim().ToLower();
                    result.Add(lcKey, new KeyValuePair<string, string>(pieces[0].Trim(), pieces[1].Trim()));
                }
            }
            return result;
        }

        /// <summary>
        /// Simple decompression of a gzip-compressed byte array
        /// </summary>
        /// <param name="compressedData"></param>
        /// <returns></returns>
        private byte[] decompressGzip(byte[] compressedData)
        {
            using (IO.MemoryStream msOut = new IO.MemoryStream(compressedData.Length * 10))
            {
                using (IO.MemoryStream msIn = new IO.MemoryStream(compressedData))
                {
                    using (IO.Compression.GZipStream ds = new IO.Compression.GZipStream(msIn, IO.Compression.CompressionMode.Decompress))
                    {
                        ds.CopyTo(msOut);
                        return msOut.GetBuffer();
                    }
                }
            }
        }
    }

    public class CommunicationEventArgs : EventArgs
    {
        public Communication Communication;
        public CommunicationEventArgs(Communication communication) { this.Communication = communication; }
    }
}
