
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Ship
{
    public class ShipmentAddresses
    {
        /// <summary>
        /// Shipper address information
        /// </summary>
        [Required]
        [ValidateObject]
        [JsonProperty("Shipper")]
        public AddressData Shipper { get; set; } = new AddressData();

        /// <summary>
        /// Shipment pickup location
        /// </summary>
        [ValidateObject]
        [JsonProperty("Pickup", NullValueHandling = NullValueHandling.Ignore)]
        public AddressData Pickup { get; set; }

        /// <summary>
        /// Address of the entity/person who requested the pickup
        /// </summary>
        [ValidateObject]
        [JsonProperty("BookingRequestor", NullValueHandling = NullValueHandling.Ignore)]
        public AddressData BookingRequestor { get; set; }

        /// <summary>
        /// Buyer address information
        /// </summary>
        [ValidateObject]
        [JsonProperty("Buyer", NullValueHandling = NullValueHandling.Ignore)]
        public AddressData Buyer { get; set; }

        /// <summary>
        /// Recipient/Consignee address information
        /// </summary>
        [Required]
        [ValidateObject]
        [JsonProperty("Recipient")]
        public AddressData Consignee { get; set; } = new AddressData();
    }
}