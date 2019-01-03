using GloWS_REST_Library.Objects.ePOD;
using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects
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

    public class shipmentDocumentRetrieveResp
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
