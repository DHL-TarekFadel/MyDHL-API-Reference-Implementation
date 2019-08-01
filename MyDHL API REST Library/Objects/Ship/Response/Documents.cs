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
        public byte[] Image { get; set; }
    }
}
