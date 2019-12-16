using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class ShippingCharges
    {
        [JsonProperty("@type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeType Type { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("Charges")]
        public Charges Charges { get; set; }
    }
}
