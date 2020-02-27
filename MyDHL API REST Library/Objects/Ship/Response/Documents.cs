using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class Documents
    {
        [JsonProperty("Document")]
        public List<Document> Document { get; set; }
    }

    public class Document
    {
        [JsonProperty("DocumentName")]
        public string Name { get; set; }

        [JsonProperty("DocumentFormat")]
        public string Format { get; set; }

        [JsonProperty("DocumentImage")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] Image { get; set; }
    }
}
