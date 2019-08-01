using Newtonsoft.Json;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class AdditionalImages
    {
        [ValidateObject]
        [CollectionLength(1000, 1)]
        [JsonProperty("DocumentImage")]
        public List<AdditionalImage> AdditionalImage { get; set; }        
    }
}