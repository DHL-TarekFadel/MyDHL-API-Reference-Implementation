using GloWS_REST_Library.Objects.Plumbing;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class Pieces
    {
        public PieceInfo PieceInfo { get; set; }
    }

    public class PieceInfo
    {
        [JsonConverter(typeof(SingleOrArrayConverter<PieceInfoItem>))]
        public List<PieceInfoItem> ArrayOfPieceInfoItem { get; set; }
    }
}