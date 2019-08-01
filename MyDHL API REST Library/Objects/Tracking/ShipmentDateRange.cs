using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class ShipmentDateRange
    {
        [Required]
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-dd")]
        public DateTime From { get; set; }

        [Required]
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-dd")]
        public DateTime To { get; set; }
    }
}