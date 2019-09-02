using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class PickUpShipment
    {
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-ddTHH:mm:sszzz")]
        public DateTime PickupTimestamp { get; set; }

        [JsonProperty("PickupLocationCloseTime")]
        [JsonConverter(typeof(CustomJSONTimespanConverter), "hh:mm")]
        public TimeSpan PickupLocationCloseTime { get; set; }

        /// <summary>
        /// Any special instructions you wish to send to the courier for the pick-up
        /// </summary>
        [StringLength(75)]
        [JsonProperty("SpecialPickupInstruction")]
        public string SpecialPickupInstruction { get; set; }

        /// <summary>
        /// Where the package should be picked up by DHL courier
        /// </summary>
        [StringLength(40)]
        [JsonProperty("PickupLocation")]
        public string PickupLocation { get; set; }

        [ValidateObject]
        public ShipmentInfo ShipmentInfo { get; set; }

        [ValidateObject]
        public InternationalDetail InternationalDetail { get; set; }

        [ValidateObject]
        [JsonProperty("Ship")]
        public AddressInformation Addresses { get; set; }

        [Required]
        [ValidateObject]
        public Packages Packages { get; set; }
    }
}
