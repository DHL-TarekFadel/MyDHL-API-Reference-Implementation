using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Ship
{
    public class RequestedPackages
    {
        [Required]
        [ValidateObject]
        [JsonProperty("RequestedPackages")]
        public List<Package> PackageList { get; set; } = new List<Package>();
    }
}