using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class Commodity
    {
        [Required]
        [StringLength(35, MinimumLength = 1)]
        [JsonProperty("Description")]
        public string ShipmentContents { get; set; }

        /// <summary>
        /// The value which needs to be declared for customs.
        /// </summary>
        [JsonProperty("CustomsValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? CustomsValue { get; set; }

        /// <summary>
        /// The US filing Type Value for shipments from the US
        /// </summary>
        [StringLength(20)]
        [JsonProperty("USFilingTypeValue", NullValueHandling = NullValueHandling.Ignore)]
        public string USFilingTypeValue { get; set; }
    }
}