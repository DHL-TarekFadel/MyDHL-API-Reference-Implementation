using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class AdditionalQuantityDefinitions
    {
        [ValidateObject]
        [CollectionLength(100, 0)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AdditionalQuantityDefinition> AdditionalQuantityDefinition { get; set; }
    }

    public class AdditionalQuantityDefinition
    {
        /// <summary>
        /// An Item's additional quantity value: example is percent of alcohol
        /// </summary>
        [Required]
        [PositiveDecimal]
        public decimal AdditionalQuantity { get; set; }

        /// <summary>
        /// Item additional quantity value UOM: example PFL=percent of alcohol
        /// </summary>
        [Required]
        [StringLength(3)]
        public string AdditionalQuantityType { get; set; }
    }
}