namespace GloWS_REST_Library.Objects.Plumbing
{
    /// <summary>
    /// Creates a UTF-8 string writer instead of the default UTF-16 used by .NET
    /// </summary>
    public class StringWriterUTF8 : System.IO.StringWriter
    {
        public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
    }
}
