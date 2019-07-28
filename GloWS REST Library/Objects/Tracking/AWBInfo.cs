using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class AWBInfo
    {

        [JsonConverter(typeof(SingleOrArrayConverter<AWBInfoItem>))]
        [ValidateObject]
        public List<AWBInfoItem> ArrayOfAWBInfoItem { get; set; }
    }
}
