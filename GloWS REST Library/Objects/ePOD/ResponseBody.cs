using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class ResponseBody
    {
        [JsonProperty("Shp")]
        public ShipmentDetail ShipmentDetail { get; set; }
    }
}