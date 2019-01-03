using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class ShipmentInputDocument
    {

        [ValidateObject]
        [JsonProperty("SDoc")]
        public ShipmentDocument ShipmentDocument { get; set; } = new ShipmentDocument();
    }
}