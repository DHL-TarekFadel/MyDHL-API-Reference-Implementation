using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
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
        public List<PieceInfoItem> PieceInfo
        {
            get
            {
                List<PieceInfoItem> retval = new List<PieceInfoItem>();

                if (null != Pieces
                    && null != Pieces.PieceInfo
                    && null != Pieces.PieceInfo.ArrayOfPieceInfoItem)
                {
                    retval = Pieces.PieceInfo.ArrayOfPieceInfoItem;
                }

                return retval;
            }
        }
    }
}