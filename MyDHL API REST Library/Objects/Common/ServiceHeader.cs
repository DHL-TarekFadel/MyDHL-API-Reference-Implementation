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

        [StringLength(20)]
        [JsonProperty("WebstorePlatform", NullValueHandling = NullValueHandling.Ignore)]
        public string WebstorePlatform { get; set; }

        [StringLength(15)]
        [JsonProperty("WebstorePlatformVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string WebstorePlatformVersion { get; set; }

        [StringLength(20)]
        [JsonProperty("ShippingSystemPlatform", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingSystemPlatform { get; set; }

        [StringLength(15)]
        [JsonProperty("ShippingSystemPlatformVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingSystemPlatformVersion { get; set; }

        [StringLength(20)]
        [JsonProperty("PlugIn", NullValueHandling = NullValueHandling.Ignore)]
        public string Plugin { get; set; }

        [StringLength(15)]
        [JsonProperty("PlugInVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string PluginVersion { get; set; }

        /// <summary>
        /// This element will get populate when existing or new customers has provided the <Request> element in the request message.
        /// This information will get populate in Response in all Error and Success scenarios.
        /// </summary>
        [JsonProperty("ServiceInvocationID", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceInvocationID { get; set; }

        public override string ToString()
        {
            return $"{MessageTime:yyyy-MM-dd HH:mm:sszzz} {MessageReference}";
        }
    }
}
