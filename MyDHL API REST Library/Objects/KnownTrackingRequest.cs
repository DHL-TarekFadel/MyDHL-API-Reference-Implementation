using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Tracking;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        [StringLength(3)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        [StringLength(4)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageScriptCode { get; set; }

        [StringLength(2)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCountryCode { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AWBNumber AWBNumber { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public LPNumber LPNumber { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceQuery ReferenceQuery { get; set; }

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
