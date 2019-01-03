using GloWS_REST_Library.Objects.Plumbing;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class ShipmentInfo
    {
        [ValidateObject]
        public ServiceArea OriginServiceArea { get; set; }

        [ValidateObject]
        public ServiceArea DestinationServiceArea { get; set; }

        public string ShipperName { get; set; }

        public string ConsigneeName { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ShipmentDate { get; set; }

        public int Pieces { get; set; }

        public decimal Weight { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<ShipmentEvent>))]
        [ValidateObject]
        public List<ShipmentEvent> ShipmentEvent { get; set; }

        [JsonIgnore]
        public List<EventItem> ShipmentEvents => ShipmentEvent.First().ArrayOfShipmentEventItem;
    }
}