using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentDocument
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [JsonProperty("@DocTyCd")]
        public string DocumentType { get; set; } = "POD";

        [JsonProperty("Img", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentImage ShipmentImage { get; set; }
    }
}