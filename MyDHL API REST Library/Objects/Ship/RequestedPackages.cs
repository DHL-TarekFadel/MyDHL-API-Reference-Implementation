using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class RequestedPackages
    {
        [Required]
        [ValidateObject]
        [CollectionLength(999, 1)]
        [JsonProperty("RequestedPackages")]
        public List<Package> PackageList { get; set; } = new List<Package>();
    }
}