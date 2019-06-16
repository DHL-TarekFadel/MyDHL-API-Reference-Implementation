using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class Commodity
    {
        [Required]
        [JsonProperty("NumberOfPieces")]
        public int NumberOfPieces { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [JsonProperty("Description")]
        public string ShipmentContents { get; set; }

        /// <summary>
        /// Country of Origin/Manufacture
        /// </summary>
        [StringLength(2)]
        [JsonProperty("CountryOfManufacture", NullValueHandling = NullValueHandling.Ignore)]
        public string COO { get; set; }

        [StringLength(10)]
        [JsonProperty("Quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; set; }

        /// <summary>
        /// Price per item in the shipment, e.g. 7.50 € if one of the books costs 7.50€.
        /// </summary>
        [JsonProperty("UnitPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// The value which needs to be declared for customs.
        /// </summary>
        [JsonProperty("CustomsValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? CustomsValue { get; set; }

        /// <summary>
        /// The US filing Type Value for shipments from the US
        /// </summary>
        [StringLength(20)]
        [JsonProperty("USFilingTypeValue", NullValueHandling = NullValueHandling.Ignore)]
        public string USFilingTypeValue { get; set; }
    }
}