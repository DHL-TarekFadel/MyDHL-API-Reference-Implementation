using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class HandlingAndFeatureCode
    {
        [JsonProperty("ServiceHandlingFeatureCode")]
        public string HandlingOrFeatureCode { get; set; }

        public override string ToString()
        {
            return this.HandlingOrFeatureCode;
        }
    }
}