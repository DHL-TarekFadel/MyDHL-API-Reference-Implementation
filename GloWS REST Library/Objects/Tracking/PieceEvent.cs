using MyDHLAPI_REST_Library.Objects.Plumbing;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class PieceEvent
    {
        [JsonConverter(typeof(SingleOrArrayConverter<EventItem>))]
        public List<EventItem> ArrayOfPieceEventItem { get; set; }
    }
}