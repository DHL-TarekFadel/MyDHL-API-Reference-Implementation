using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class LandedCost
    {
        /// <summary>
        /// Yes: item cost breakdown will be returned, No: item cost breakdown will not be returned
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? GetItemCostBreakdown { get; set; }

        [Required]
        [StringLength(3)]
        public string ShipmentCurrencyCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LandedCostShipmentPurpose ShipmentPurpose { get; set; }

        [JsonProperty("ShipmentTransportationMode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LandedCostModeOfTransportType ModeOfTransport { get; set; }

        [JsonProperty("MerchantSelectedCarrierName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LandedCostCarrierName CarrierName { get; set; }

        [Required]
        [ValidateObject]
        [JsonProperty("Items")]
        public LandedCostItems Items { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentMonetaryAmount ShipmentMonetaryAmount { get; set; }
    }
}