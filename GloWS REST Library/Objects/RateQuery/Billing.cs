using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery {
    public class Billing {
        public string ShipperAccountNumber { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PaymentTypes ShippingPaymentType { get; set; }

        [AccountNumberRequiredIf("ShippingPaymentType")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BillingAccountNumber { get; set; }
    }
}