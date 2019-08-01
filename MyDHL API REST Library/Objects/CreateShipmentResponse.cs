using MyDHLAPI_REST_Library.Objects.Common.Response;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using MyDHLAPI_REST_Library.Objects.Ship.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects
{
    public class CreateShipmentResponse
    {
        [JsonProperty("ShipmentResponse")]
        public ShipmentResponse Data { get; set; }
    }

    public class ShipmentResponse
    {
        [JsonProperty("Response")]
        public Response Response { get; set; }

        [JsonProperty("Notification")]
        public List<Notification> Notifications { get; set; }

        [JsonProperty("Warning")]
        public List<Notification> Warhings { get; set; }

        [JsonProperty("ShipmentIdentificationNumber")]
        public string AWB { get; set; }

        [JsonProperty("PackagesResult")]
        public PieceResults PieceResults { get; set; } = new PieceResults();

        [JsonIgnore]
        public List<Piece> Pieces => this.PieceResults.Pieces;

        [JsonProperty("LabelImage")]
        public List<ShipmentImage> Labels { get; set; }

        [JsonProperty("Documents")]
        public Documents Documents { get; set; }

        [JsonProperty("TotalNet")]
        [JsonConverter(typeof(SingleOrArrayConverter<ShippingCharges>))]
        public List<ShippingCharges> ShippingCharges { get; set; }

        [JsonProperty("AdditionalInformation")]
        public AdditionalInformation AdditionalInformation { get; set; }

        [JsonProperty("DispatchConfirmationNumber")]
        public string BookingReferenceNumber { get; set; }

        [JsonProperty("OnDemandDeliveryURL")]
        public string ODDUrl { get; set; }
    }
}
