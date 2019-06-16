using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Common.Response {
    public class Notification {
        [JsonProperty("@code")]
        public string Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}