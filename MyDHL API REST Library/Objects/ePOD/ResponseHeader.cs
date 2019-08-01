using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ResponseHeader
    {
        [JsonProperty("@Ver")]
        public string Version { get; set; }

        [JsonProperty("@Id")]
        public string Id { get; set; }

        [JsonProperty("@Dtm")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Sndr")]
        public SenderInfo SenderApplication { get; set; }

        [JsonProperty("Rcp")]
        public ReceiverInfo ReceiverApplication { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp}] {Id}";
        }
    }
}