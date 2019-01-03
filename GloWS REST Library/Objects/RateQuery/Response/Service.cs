using System;
using System.Collections.Generic;
using GloWS_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GloWS_REST_Library.Objects.RateQuery.Response {
    public class Service {
        [JsonProperty("@type")]
        public string ProductCode { get; set; }

        public ProductCharges TotalNet { get; set; }

        public Charges Charges { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DeliveryTime { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CutoffTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo NextBusinessDayInd { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Product: {ProductCode}, Price: {TotalNet.Currency} {TotalNet.Amount:#,##0.00}";
        }
    }
}