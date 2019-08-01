using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ResponseBody
    {
        [JsonProperty("Shp")]
        public ShipmentDetail ShipmentDetail { get; set; }
    }
}