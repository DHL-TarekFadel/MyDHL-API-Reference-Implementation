using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class ShipmentReferences
    {
        [Required]
        [StringLength(35)]
        public string ShipmentReference { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentReferenceType ShipmentReferenceType { get; set; } = Enums.ShipmentReferenceType.Consignor;
    }
}