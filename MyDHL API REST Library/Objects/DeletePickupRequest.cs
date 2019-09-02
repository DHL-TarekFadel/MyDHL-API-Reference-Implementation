using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects
{
    public class DeletePickupRequest
    {
        public DeleteRequest DeleteRequest { get; set; }
    }

    public class DeleteRequest
    {
        [ValidateObject]
        public Request Request { get; set; }

        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-dd")]
        public DateTime PickupDate { get; set; }

        [Required]
        [StringLength(2)]
        public string PickupCountry { get; set; }

        [Required]
        [StringLength(20)]
        [JsonProperty("DispatchConfirmationNumber")]
        public string PickupRequestNumber { get; set; }

        [Required]
        [StringLength(45)]
        public string RequestorName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DeletePickupRequestReason? Reason { get; set; }
    }
}
