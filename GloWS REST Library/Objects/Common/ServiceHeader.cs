using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Common
{
    public class ServiceHeader
    {
        
        [Required]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime MessageTime { get; set; } = DateTime.Now;

        [Required]
        [StringLength(35, MinimumLength = 28)]
        public string MessageReference { get; set; } = Guid.NewGuid().ToString("N");

        public override string ToString()
        {
            return $"{MessageTime:yyyy-MM-dd HH:mm:sszzz} {MessageReference}";
        }
    }
}
