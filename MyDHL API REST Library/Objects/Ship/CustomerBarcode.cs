using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class CustomerBarcode
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.CustomerBarcodeType? BarcodeType { get; set; }

        [JsonProperty("BarcodeContent", NullValueHandling = NullValueHandling.Ignore)]
        public string BarcodeData { get; set; }

        [JsonProperty("TextBelowBarcode", NullValueHandling = NullValueHandling.Ignore)]
        public string BarcodeText { get; set; }
    }
}