using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Ship
{
    public class Package
    {
        /// <summary>
        /// Running number of the packages
        /// </summary>
        [Required]
        [PositiveInteger]
        [JsonProperty("@number")]
        public int Number { get; set; }

        /// <summary>
        /// Insurance values of the package
        /// </summary>
        [PositiveDecimal]
        [JsonProperty("InsuredValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InsuredValue { get; set; }

        /// <summary>
        /// The weight of the package (15.3)
        /// </summary>
        [Required]
        [PositiveDecimal]
        [JsonProperty("Weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Y = allows you to define your own PieceID in the tag below
        /// N = Auto-allocates the PieceID from DHL Express
        /// You can request your own Piece ID range from your DHL Express IT consultant and store these locally in your integration however this is not needed as if you leave this tag then DHL will automatically assign the piece ID centrally.
        /// In addition this special function needs to be enabled for your username by your DHL Express IT Consultant.
        /// </summary>
        [JsonProperty("UseOwnPieceIdentificationNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? UseOwnPieceId { get; set; }

        /// <summary>
        /// You can request your own Piece ID range from your DHL Express IT consultant and store these locally in your integration however this is not needed as if you leave this tag then DHL will automatically assign the piece ID centrally.
        /// If you wish to use this function then the field tag UseOwnPieceId needs to be set as Y
        /// </summary>
        [StringLength(35)]
        [JsonProperty("PieceIdentificationNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string OwnPieceId { get; set; }

        /// <summary>
        /// Allows you to provide the content description on a piece level instead of Shipment level
        /// </summary>
        [StringLength(70)]
        [JsonProperty("PackageContentDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string PieceContents { get; set; }

        [ValidateObject]
        [JsonProperty("Dimensions", NullValueHandling = NullValueHandling.Ignore)]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// Customer Reference for the piece.
        /// </summary>
        [StringLength(35, MinimumLength = 1)]
        [JsonProperty("CustomerReferences", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerReferences { get; set; }
    }
}