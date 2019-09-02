using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class Packages
    {
        [ValidateObject]
        [CollectionRequired]
        [JsonProperty("RequestedPackages")]
        public List<Package> PackageList { get; set; }
    }

    public class Package
    {
        [JsonProperty("@number")]
        public int PackageNumber { get; set; }

        [Required]
        [PositiveDecimal]
        public decimal Weight { get; set; }

        [Required]
        [StringLength(35)]
        public string CustomerReferences { get; set; }

        [ValidateObject]
        public Dimensions Dimensions { get; set; }
    }
}