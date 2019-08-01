using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentDetail
    {
        [Required]
        [AWBNumber]
        [JsonProperty("@Id")]
        public string AWB { get; set; }

        [ValidateObject]
        [JsonProperty("ShpTr", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentTransaction ShipmentTransaction { get; set; }

        [ValidateObject]
        [JsonProperty("ShpInDoc")]
        public ShipmentInputDocument ShipmentInputDocument { get; protected set; } = new ShipmentInputDocument();
    }
}