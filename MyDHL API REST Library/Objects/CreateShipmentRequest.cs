using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Ship;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects
{
    public class CreateShipmentRequest
    {
        [ValidateObject]
        [JsonProperty("ShipmentRequest")]
        public ShipmentRequest ShipmentRequest { get; set; } = new ShipmentRequest();

        /// <summary>
        /// Used for easier access (expands to ShipmentRequest.RequestedShipment
        /// </summary>
        [JsonIgnore]
        public RequestedShipment Data => ShipmentRequest.RequestedShipment;
    }

    public class ShipmentRequest
    {
        [ValidateObject]
        [JsonProperty("Request", NullValueHandling = NullValueHandling.Ignore)]
        public Request Request { get; set; }

        [ValidateObject]
        [JsonProperty("ClientDetail", NullValueHandling = NullValueHandling.Ignore)]
        public ClientDetails ClientDetail { get; set; }

        [ValidateObject]
        [JsonProperty("RequestedShipment")]
        public RequestedShipment RequestedShipment { get; set; } = new RequestedShipment();
    }
}
