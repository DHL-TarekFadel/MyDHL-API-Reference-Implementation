using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class ShipmentReferences
    {
        [ValidateObject]
        [CollectionLength(999, 1)]
        [JsonProperty("ShipmentReference")]
        public List<ShipmentReference> ShipmentReference { get; set; }
    }
}