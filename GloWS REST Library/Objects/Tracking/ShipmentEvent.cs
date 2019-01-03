using GloWS_REST_Library.Objects.Plumbing;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class ShipmentEvent
    {
        [JsonConverter(typeof(SingleOrArrayConverter<EventItem>))]
        [ValidateObject]
        public List<EventItem> ArrayOfShipmentEventItem { get; set; }
    }    
}