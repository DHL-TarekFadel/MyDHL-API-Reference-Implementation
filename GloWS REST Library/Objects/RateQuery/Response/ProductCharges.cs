using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response {
    public class ProductCharges {

        [JsonProperty("@type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeType? ChargeType { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }
    }
}