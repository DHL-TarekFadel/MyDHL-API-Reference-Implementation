using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class EventItem
    {
        public DateTime @Date { get; set; }

        public TimeSpan @Time { get; set; }

        [ValidateObject]
        public ServiceEvent ServiceEvent { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Signatory { get; set; }

        [ValidateObject]
        public ServiceArea ServiceArea { get; set; }

        public ShipperReference ShipperReference { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} {Time} | ({ServiceEvent.EventCode}) {ServiceEvent.Description.Trim()} @ {ServiceArea.ServiceAreaCode}{ServiceArea.FacilityCode} {ServiceArea.Description}";
        }
    }

    public class ServiceEvent
    {
        public string EventCode { get; set; }

        public string Description { get; set; }
    }
}
