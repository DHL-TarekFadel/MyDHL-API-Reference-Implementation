using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
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

        /// <summary>
        /// Parent (Mother) Piece ID number. This field will be used to indicate the Mother Shipment's Piece ID for linkage purposes.
        /// </summary>
        [StringLength(35)]
        [JsonProperty("ParentPieceIdentificationNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string BBXMotherPieceIDNumber { get; set; }

        /// <summary>
        /// Customer Reference for the piece.
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1)]
        [JsonProperty("CustomerReferences", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerReferences { get; set; }

        [JsonProperty("CustomerReferenceType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentReferenceType? CustomerReferenceType { get; set; }

        /// <summary>
        /// The type of packaging used (ex: Box, Express Envelope, etc.)
        /// </summary>
        [JsonProperty("PackageTypeCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PackageTypeCode? PackagingType { get; set; }

        [ValidateObject]
        [JsonProperty("Dimensions", NullValueHandling = NullValueHandling.Ignore)]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// BespokeLabelData is only applicable when LabelTemplate="ECOM26_84CI_003"
        /// </summary>
        [ValidateObject]
        [JsonProperty("BespokeLabelData", NullValueHandling = NullValueHandling.Ignore)]
        public BespokeLabelData BespokeLabelData { get; set; }
    }

    public class BespokeLabelData
    {
        /// <summary>
        /// The additional customer description
        /// </summary>
        [Required]
        [StringLength(80)]
        public string LabelDescription { get; set; }

        [ValidateObject]
        [JsonProperty("LabelBarcodes", NullValueHandling = NullValueHandling.Ignore)]
        public LabelBarcodes LabelBarcodes { get; set; }

        [ValidateObject]
        [JsonProperty("LabelTextEntries", NullValueHandling = NullValueHandling.Ignore)]
        public LabelTextEntries LabelTextEntries { get; set; }
    }

    public class LabelBarcodes
    {
        [ValidateObject]
        [CollectionLength(2, 1)]
        [JsonProperty("LabelBarcode")]
        public List<LabelBarcode> LabelBarcode { get; set; }
    }

    public class LabelBarcode
    {
        [Required]
        [JsonConverter(typeof(ForceQuotedJSONStringConverter))]
        public int BarcodeNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Would be a breaking change.")]
        public Enums.CustomerBarcodeType BarcodeType = Enums.CustomerBarcodeType.Code128;

        [Required]
        [JsonProperty("BarcodeContent")]
        public string BarcodeData { get; set; }

        [Required]
        [JsonProperty("TextBelowBarcode")]
        public string BarcodeText { get; set; }
    }

    public class LabelTextEntries
    {

        [ValidateObject]
        [CollectionLength(6, 1)]
        [JsonProperty("LabelTextEntry")]
        public List<LabelTextEntry> LabelTextEntry { get; set; }
    }
    
    public class LabelTextEntry
    {
        /// <summary>
        /// Barcode sequence number
        /// </summary>
        [Required]
        [JsonConverter(typeof(ForceQuotedJSONStringConverter))]
        public int LabelNumber { get; set; }

        /// <summary>
        /// The caption to be printed in the tag value
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LabelCaption { get; set; }

        /// <summary>
        /// The value to be printed for the respective tag in caption (eg. "SALES", "50", "CN", "SG Regional")
        /// </summary>
        [Required]
        [StringLength(40)]
        public string LabelDescription { get; set; }
    }
}