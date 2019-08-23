using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD.Response
{
    public class ResponseBody
    {
        [JsonProperty("Shp")]
        public ShipmentDetail ShipmentDetail { get; set; }
    }
}