using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD {
    public class MessageBody {

        [ValidateObject]
        [JsonProperty("Shp")]
        public ShipmentDetail ShipmentDetails { get; protected set; } = new ShipmentDetail();

        [ValidateObject]
        [JsonProperty("GenrcRq")]
        public RequestCriteria RequestCriteria { get; protected set; } = new RequestCriteria();
    }
}