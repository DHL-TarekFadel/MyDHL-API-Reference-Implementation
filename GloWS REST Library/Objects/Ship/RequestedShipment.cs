using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class RequestedShipment
    {
        [Required]
        [ValidateObject]
        [JsonProperty("ShipmentInfo")]
        public ShipmentInfo ShipmentInfo { get; set; } = new ShipmentInfo();

        [JsonProperty("ShipTimestamp")]
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy'-'MM'-'dd'T'HH':'mm':'ss 'GMT'zzz")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("PickupLocationCloseTime", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? PickupLocationCloseTime { get; set; }

        [StringLength(75)]
        [JsonProperty("SpecialPickupInstruction", NullValueHandling = NullValueHandling.Ignore)]
        public string PickupInstructions { get; set; }

        [StringLength(40)]
        [JsonProperty("PickupLocation", NullValueHandling = NullValueHandling.Ignore)]
        public string PickupLocation { get; set; }

        [Required]
        [JsonProperty("PaymentInfo")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.TermsOfTrade TermsOfTrade { get; set; }

        [ValidateObject]
        [JsonProperty("InternationalDetail")]
        public InternationalDetail CustomsInformation { get; set; } = new InternationalDetail();

        [ValidateObject]
        [JsonProperty("OnDemandDeliveryOptions", NullValueHandling = NullValueHandling.Ignore)]
        public ODD ODD { get; set; }

        [ValidateObject]
        [JsonProperty("Ship")]
        public ShipmentAddresses ShipmentAddresses { get; set; } = new ShipmentAddresses();

        [Required]
        [ValidateObject]
        [JsonProperty("Packages")]
        public RequestedPackages Packages { get; set; } = new RequestedPackages();

        [ValidateObject]
        [JsonProperty("DangerousGoods", NullValueHandling = NullValueHandling.Ignore)]
        public DangerousGoods DG { get; set; }
    }
}
