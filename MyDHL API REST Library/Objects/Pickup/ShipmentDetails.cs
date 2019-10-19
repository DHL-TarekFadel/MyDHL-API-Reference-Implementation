using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class ShipmentDetails
    {
        [ValidateObject]
        public ShipmentDetail ShipmentDetail { get; set; } = new ShipmentDetail();
    }

    public class ShipmentDetail
    {
        [StringLength(1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceType { get; set; }

        [StringLength(1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LocalServiceType { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UnitOfMeasurement UnitOfMeasurement { get; set; }

        [JsonProperty("Content", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentType? ContentType { get; set; }

        /// <summary>
        /// The airbill number associated to this shipment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ShipmentIdentificationNumber { get; set; }

        [PositiveInteger]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfPieces => Packages.PackageList.Count;

        /// <summary>
        /// The total weight of the shipment.
        /// </summary>
        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ShipmentWeight { get; set; }

        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? DeclaredValue { get; set; }

        [StringLength(3)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DeclaredValueCurrencyCode { get; set; }

        [Required]
        [ValidateObject]
        public Packages Packages { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SpecialServices SpecialServices { get; set; }
    }
}
