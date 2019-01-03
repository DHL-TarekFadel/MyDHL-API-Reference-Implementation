using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class ServiceArea
    {
        public string ServiceAreaCode { get; set; }

        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FacilityCode { get; set; }
    }
}