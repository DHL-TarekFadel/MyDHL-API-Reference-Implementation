using MyDHLAPI_REST_Library.Objects.ePOD;
using MyDHLAPI_REST_Library.Objects.ePOD.Response;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects
{
    public class EPodResponse
    {
        public shipmentDocumentRetrieveResp shipmentDocumentRetrieveResp { get; set; }

        [JsonIgnore]
        public ResponseHeader ResponseHeader => shipmentDocumentRetrieveResp.ResponseMessage.ResponseHeader;

        [JsonIgnore]
        public ResponseBody ResponseBody => shipmentDocumentRetrieveResp.ResponseMessage.ResponseBody;

        [JsonIgnore]
        public ShipmentImage EPod => ResponseBody.ShipmentDetail.ShipmentInputDocument.ShipmentDocument.ShipmentImage;
    }

#pragma warning disable IDE1006 // Naming Styles
    public class shipmentDocumentRetrieveResp
#pragma warning restore IDE1006 // Naming Styles
    {
        [JsonProperty("MSG")]
        public ResponseMessage ResponseMessage {get;set;}
    }

    public class ResponseMessage
    {
        [JsonProperty("Hdr")]
        public ResponseHeader ResponseHeader { get; set; }

        [JsonProperty("Bd")]
        public ResponseBody ResponseBody { get; set; }
    }
}
