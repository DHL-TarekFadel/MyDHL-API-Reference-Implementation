using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class ShipmentReference
    {
        [Required]
        [StringLength(35)]
        [JsonProperty("ShipmentReference")]
        public string Reference { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentReferenceType ShipmentReferenceType { get; set; } = Enums.ShipmentReferenceType.Consignor;
    }
}