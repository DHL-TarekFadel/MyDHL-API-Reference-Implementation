using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class PickUpShipment
    {
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-ddTHH:mm:sszzz")]
        public DateTime PickupTimestamp { get; set; }

        [JsonProperty("PickupLocationCloseTime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(CustomJSONTimespanConverter), "hh:mm")]
        public TimeSpan PickupLocationCloseTime { get; set; }

        /// <summary>
        /// Any special instructions you wish to send to the courier for the pick-up
        /// </summary>
        [StringLength(75)]
        [JsonProperty("SpecialPickupInstruction", NullValueHandling = NullValueHandling.Ignore)]
        public string SpecialPickupInstruction { get; set; }

        /// <summary>
        /// Remarks Field
        /// @TODO get a proper description and size limit
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Remarks { get; set; }

        /// <summary>
        /// Where the package should be picked up by DHL courier
        /// </summary>
        [StringLength(40)]
        [JsonProperty("PickupLocation", NullValueHandling = NullValueHandling.Ignore)]
        public string PickupLocation { get; set; }

        /// <summary>
        /// Type of pickup location (Commercial or Residential)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PickupLocationType? PickupLocationType { get; set; }

        [ValidateObject]
        public ShipmentDetails ShipmentDetails { get; set; }

        [ValidateObject]
        public Billing Billing { get; set; }

        [ValidateObject]
        [JsonProperty("Ship")]
        public AddressInformation Addresses { get; set; }
    }
}
