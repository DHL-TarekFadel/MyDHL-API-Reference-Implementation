using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Tracking;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MyDHLAPI_REST_Library.Objects
{
    /// <summary>
    /// Tracking using a known tracking number (AWB or LPN)
    /// </summary>
    public class KnownTrackingRequest
    {
        [ValidateObject]
        public Request Request { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AWBNumber AWBNumber { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LevelOfDetails LevelOfDetails { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PiecesEnabled PiecesEnabled { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.EstimatedDeliveryDateEnabled? EstimatedDeliveryDateEnabled { get; set; }

        public static ExpandoObject DecorateRequest(KnownTrackingRequest ktr)
        {
            dynamic obj = new ExpandoObject();
            obj.trackShipmentRequest = new ExpandoObject();
            obj.trackShipmentRequest.trackingRequest = new ExpandoObject();
            obj.trackShipmentRequest.trackingRequest.TrackingRequest = ktr;

            return obj;
        }
    }
}
