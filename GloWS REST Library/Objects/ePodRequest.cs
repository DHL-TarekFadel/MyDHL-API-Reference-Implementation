using GloWS_REST_Library.Objects.ePOD;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects {

    public class EPodRequest
    {
        [ValidateObject]
        [JsonProperty("shipmentDocumentRetrieveReq")]
        public EPodRequestStart Request { get; protected set; } = new EPodRequestStart();

        [JsonIgnore]
        public MessageHeader Header => Request.Message.Header;

        [JsonIgnore]
        public MessageBody Body => Request.Message.Body;
    }

    public class EPodRequestStart {
        [ValidateObject]
        [JsonProperty("MSG")]
        public Message Message { get; protected set; } = new Message();
    }

    public class Message
    {
        [ValidateObject]
        [JsonProperty("Hdr")]
        public MessageHeader Header { get; protected set; } = new MessageHeader();

        [ValidateObject]
        [JsonProperty("Bd")]
        public MessageBody Body { get; protected set; } = new MessageBody();
    }
}
