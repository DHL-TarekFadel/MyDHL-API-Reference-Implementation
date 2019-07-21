using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery {
    public class RequestedPackages {

        [PositiveInteger]
        [JsonProperty("@number")]
        public int PieceNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Enums.PackageTypeCode? PackageTypeCode { get; set; }

        public Weight Weight { get; set; }

        public Dimensions Dimensions { get; set; }
    }
}