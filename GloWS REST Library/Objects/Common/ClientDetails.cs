using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.Common {
    public class ClientDetails {
        public string Sso { get; set; }

        [JsonProperty("plant")]
        public string Plant { get; set; }
    }
}