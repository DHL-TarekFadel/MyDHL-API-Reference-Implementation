using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Common.Response {
    public class Notification {
        /// <summary>
        /// Error > 0 or Success Code = 0
        /// </summary>
        [JsonProperty("@code")]
        public string Code { get; set; }

        /// <summary>
        /// Response Message
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}