using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Common
{
    public class ShipmentReferences
    {
        [ValidateObject]
        [CollectionLength(999, 1)]
        [JsonProperty("ShipmentReference")]
        public List<ShipmentReference> ShipmentReference { get; set; }
    }
}