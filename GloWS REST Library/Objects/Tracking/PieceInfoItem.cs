using MyDHLAPI_REST_Library.Objects.Plumbing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class PieceInfoItem
    {
        public PieceDetails PieceDetails { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<PieceEvent>))]
        public List<PieceEvent> PieceEvent { get; set; }

        [JsonIgnore]
        public List<EventItem> PieceEvents
        {
            get { return (PieceEvent.First() != null ? PieceEvent.First().ArrayOfPieceEventItem : null); }
        }
    }
}