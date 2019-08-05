using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class HandlingAndFeatureCode
    {
        [JsonProperty("ServiceHandlingFeatureCode")]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> HandlingOrFeatureCode { get; set; }

        public override string ToString()
        {
            return string.Join(", ", this.HandlingOrFeatureCode);
        }
    }
}