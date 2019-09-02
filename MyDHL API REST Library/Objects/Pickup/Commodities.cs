using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class Commodities
    {
        [PositiveInteger]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfPieces { get; set; }

        [Required]
        [StringLength(35)]
        [JsonProperty("Description")]
        public string ShipmentContentsDescription { get; set; }
    }
}