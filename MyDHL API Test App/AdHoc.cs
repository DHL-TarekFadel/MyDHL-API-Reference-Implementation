using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScintillaNET;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace MyDHLAPI_Test_App
{
    public partial class AdHoc : Form
    {
        Scintilla soapTextbox;
        Scintilla jsonTextbox;
        Scintilla resultTextbox;

        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        public AdHoc()
        {
            InitializeComponent();
        }

        private void AdHoc_Load(object sender, EventArgs e)
        {
            soapTextbox = new Scintilla();
            jsonTextbox = new Scintilla();
            resultTextbox = new Scintilla();

            ApplyTemplate(ref txtSOAP, ref soapTextbox);
            ApplyTemplate(ref txtJSON, ref jsonTextbox);
            ApplyTemplate(ref txtResult, ref resultTextbox);

            InitCodeEditor(ref soapTextbox, Lexer.Xml);
            InitCodeEditor(ref jsonTextbox, Lexer.Json);
            InitCodeEditor(ref resultTextbox, Lexer.Null);

            InitSyntaxHighlighting(ref soapTextbox);
            InitSyntaxHighlighting(ref jsonTextbox);

            this.Controls.Add(soapTextbox);
            this.Controls.Add(jsonTextbox);
            this.Controls.Add(resultTextbox);
        }

        private void ApplyTemplate(ref TextBox template, ref Scintilla txt)
        {
            txt.Size = template.Size;
            txt.Location = template.Location;
            txt.ReadOnly = template.ReadOnly;
            txt.Anchor = template.Anchor;
        }

        private void InitCodeEditor(ref Scintilla txt, Lexer lexer)
        {
            txt.Lexer = lexer;

            txt.WrapMode = WrapMode.None;
            txt.IndentationGuides = IndentView.LookBoth;
            txt.Styles[Style.Default].Font = "Consolas";

            // Setup line numbers margin
            var nums = txt.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            // Setup folding
            txt.SetProperty("fold", "1");
            txt.SetProperty("font.compact", "1");

            var folds = txt.Margins[FOLDING_MARGIN];
            folds.Type = MarginType.Symbol;
            folds.Mask = Marker.MaskFolders;
            folds.Sensitive = true;
            folds.Width = 20;

            // Configure folding markers with respective symbols
            txt.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            txt.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            txt.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            txt.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            txt.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            txt.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            txt.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            txt.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void InitSyntaxHighlighting(ref Scintilla tbx)
        {
            switch (tbx.Lexer)
            {
                case Lexer.Json:
                    tbx.Styles[Style.Json.String].ForeColor = Color.DarkBlue;
                    tbx.Styles[Style.Json.PropertyName].ForeColor = Color.Green;
                    break;
                default:
                    break;
            }
        }

        private void BtnFromJSON_Click(object sender, EventArgs e)
        {

        }

        private void BtnFromSOAP_Click(object sender, EventArgs e)
        {

        }

        private void BtnRunSOAP_Click(object sender, EventArgs e)
        {

        }

        private void BtnRunJSON_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                JToken jsonObject;
                try
                {

                    jsonObject = GetJTokenFromString(jsonTextbox.Text);
                }
                catch (Exception ex)
                {
                    SetResultText(ex.Message, Lexer.Null, false);
                    return;
                }

                var methodProperty = ((JObject)jsonObject).Properties().First().Name;

                if (methodProperty.Equals("PickUpRequest"))
                {
                    methodProperty = "PickupRequest";
                }
                if (methodProperty.Equals("trackShipmentRequest"))
                {
                    methodProperty = "TrackingRequest";
                }

                string jsonText = string.Empty;

                using (StringWriter sw = new StringWriter())
                {
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        JsonSerializer.CreateDefault().Serialize(jw, jsonObject);

                        jsonText = sw.ToString();
                    }
                }

                try
                {
                    byte[] auth = Encoding.ASCII.GetBytes($"{Common.CurrentCredentials["Username"]}:{Common.CurrentCredentials["Password"]}");

                    httpClient.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("Basic"
                                                        , Convert.ToBase64String(auth));
                    HttpResponseMessage resp = httpClient.PostAsync($"{Common.CurrentRestBaseUrl}/{methodProperty}", new StringContent(jsonText, Encoding.UTF8, "application/json")).Result;

                    if (!resp.IsSuccessStatusCode)
                    {
                        resultTextbox.Text = $"HTTP Status Code: {(int)resp.StatusCode} {resp.ReasonPhrase}";
                    }
                    else
                    {
                        JToken respJson = GetJTokenFromString(resp.Content.ReadAsStringAsync().Result);

                        SetResultText(respJson.ToString());
                    }
                }
                catch (WebException wex)
                {
                    InitSyntaxHighlighting(ref resultTextbox);
                    resultTextbox.Text = $"Exception: {wex.Message}";
                }

            }
            finally
            {
                this.Enabled = true;
                this.UseWaitCursor = false;
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void SetResultText(string result, Lexer lexer = Lexer.Json, bool setSyntaxHighlighting = true)
        {
            InitCodeEditor(ref resultTextbox, lexer);

            if (setSyntaxHighlighting)
            {
                InitSyntaxHighlighting(ref resultTextbox);
            }

            resultTextbox.ReadOnly = false;
            resultTextbox.Text = result;
            resultTextbox.ReadOnly = true;
        }

        private JToken GetJTokenFromString(string json)
        {
            StringReader sr = new StringReader(json);
            JToken jt = null;
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                jt = JToken.ReadFrom(reader);
            }

            return jt;
        }
    }
}
