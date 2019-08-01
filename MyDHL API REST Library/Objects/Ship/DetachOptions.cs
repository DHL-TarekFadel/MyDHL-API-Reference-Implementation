using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class DetachOptions
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? AllInOnePDF { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? SplitShipmentReceiptAndCustomsInvoice { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? SplitTransportLabelAndWaybillDocument { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? SplitLabelsByPieces { get; set; }

    }
}