using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class ShipmentInfo
    {
        /// <summary>
        /// The shipping product requested for this shipment, corresponding to the DHL Global Product codes.
        /// </summary>
        [JsonProperty("ServiceType")]
        [StringLength(1)]
        public string ShippingProductCode { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UnitOfMeasurement UnitOfMeasurement { get; set; }

        [ValidateObject]
        public Billing Billing { get; set; }

    }
}