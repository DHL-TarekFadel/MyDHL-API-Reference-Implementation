using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentInputDocument
    {

        [ValidateObject]
        [JsonProperty("SDoc")]
        public ShipmentDocument ShipmentDocument { get; protected set; } = new ShipmentDocument();
    }
}