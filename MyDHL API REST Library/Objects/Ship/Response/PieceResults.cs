using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class PieceResults
    {
        [JsonProperty("PackageResult")]
        public List<Piece> Pieces { get; set; } = new List<Piece>();
    }

    public class Piece
    {
        [JsonProperty("@number")]
        public int PieceNumber { get; set; }

        [JsonProperty("TrackingNumber")]
        public string LPN { get; set; }
    }
}