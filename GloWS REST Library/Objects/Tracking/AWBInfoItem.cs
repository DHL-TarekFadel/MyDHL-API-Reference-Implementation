using GloWS_REST_Library.Objects.Plumbing;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GloWS_REST_Library.Objects.Tracking
{
    public class AWBInfoItem
    {
        [AWBNumber]
        public string AWBNumber { get; set; }

        [ValidateObject]
        public Status Status { get; set; }

        [ValidateObject]
        public ShipmentInfo ShipmentInfo { get; set; }

        [ValidateObject]
        public Pieces Pieces { get; set; }

        [JsonIgnore]
        public List<PieceInfoItem> PieceInfo => Pieces.PieceInfo.ArrayOfPieceInfoItem;
    }
}