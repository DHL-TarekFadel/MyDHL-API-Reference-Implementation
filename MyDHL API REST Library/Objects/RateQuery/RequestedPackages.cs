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

        public RequestedPackages() { }

        public RequestedPackages(int pieceNumber, decimal weight, decimal height, decimal width, decimal depth)
        {
            this.PieceNumber = pieceNumber;
            this.Weight = new Weight() { Value = weight };
            this.Dimensions = new Dimensions(height, width, depth);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Would cause braking change.")]
        public static implicit operator RequestedPackages(Objects.Ship.Package p)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != p);

            return new RequestedPackages(p.Number, p.Weight, p.Dimensions.Height, p.Dimensions.Width, p.Dimensions.Length);
        }
    }
}