using System;
using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD {
    public class MessageHeader
    {
        /// <summary>
        /// Request Id
        /// </summary>
        [StringLength(20)]
        [JsonProperty("@Id")]
        public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(12);

        /// <summary>
        /// Always use this value: 1.038
        /// </summary>
        [StringLength(7)]
        [JsonProperty("@Ver")]
        public string Version { get; } = "1.038";

        /// <summary>
        /// Format: 2013-04-07T23:59:59
        /// </summary>
        [JsonProperty("@Dtm")]
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-ddTHH:mm:sszzz")]
        public DateTime Timestamp { get; } = DateTime.Now;

        /// <summary>
        /// Correlation ID. This field is only used in the response. No need to send in the request.
        /// </summary>
        [JsonProperty("@CorrId", NullValueHandling = NullValueHandling.Ignore)]
        public string CorrelationId { get; set; }

        // ReSharper disable once StringLiteralTypo
        [ValidateObject]
        [JsonProperty("Sndr")]
        public SenderInfo SenderInfo { get; set; } = new SenderInfo();
    }
}