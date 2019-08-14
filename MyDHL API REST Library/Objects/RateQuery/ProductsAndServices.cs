using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class ProductsAndServices
    {
        [ValidateObject]
        [CollectionLength(99, 0)]
        public List<ProductAndServices> ProductAndServices { get; set; }
    }

    public class ProductAndServices
    {
        /// <summary>
        /// The shipping product requested for this shipment, corresponding to the DHL Global Product codes.
        /// </summary>
        [Required]
        [StringLength(3)]
        public string ServiceType { get; set; }

        /// <summary>
        /// DHL “local / country specific” Product Code used to ship the items.
        /// </summary>
        [StringLength(1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LocalServiceType { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SpecialServices SpecialServices { get; set; }
    }
}