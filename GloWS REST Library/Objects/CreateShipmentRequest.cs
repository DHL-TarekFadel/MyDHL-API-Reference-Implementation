using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using GloWS_REST_Library.Objects.Ship;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects
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
        [Required]
        [StringLength(200)]
        [JsonProperty("MessageId")]
        public string MessageId
        {
            get { return System.Guid.NewGuid().ToString("N"); }
            set { MessageId = value; }
        }

        [ValidateObject]
        [JsonProperty("ClientDetail", NullValueHandling = NullValueHandling.Ignore)]
        public ClientDetails ClientDetail { get; set; }

        [ValidateObject]
        [JsonProperty("RequestedShipment")]
        public RequestedShipment RequestedShipment { get; set; } = new RequestedShipment();
    }
}
