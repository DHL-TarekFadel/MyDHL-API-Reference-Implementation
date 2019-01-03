using GloWS_REST_Library.Objects.Common.Response;
using GloWS_REST_Library.Objects.Ship.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GloWS_REST_Library.Objects
{
    public class CreateShipmentResponse
    {
        [JsonProperty("ShipmentResponse")]
        public ShipmentResponse Data { get; set; }
    }

    public class ShipmentResponse
    {
        [JsonProperty("Notification")]
        public List<Notification> Notifications { get; set; }

        [JsonProperty("PackagesResult")]
        public PieceResults PieceResults { get; set; } = new PieceResults();

        [JsonIgnore]
        public List<Piece> Pieces => this.PieceResults.Pieces;

        [JsonProperty("LabelImage")]
        public List<ShipmentImage> Labels { get; set; }

        [JsonProperty("ShipmentIdentificationNumber")]
        public string AWB { get; set; }

        [JsonProperty("DispatchConfirmationNumber")]
        public string BookingReferenceNumber { get; set; }
    }
}
