using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class LandedCostItems
    {
        [ValidateObject]
        [CollectionLength(1000, 1)]
        [JsonProperty("Item")]
        public List<LandedCostItem> Item { get; set; }
    }

    public class LandedCostItem
    {
        [PositiveInteger]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ItemNumber { get; set; }

        [StringLength(512)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [StringLength(255)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Remark { get; set; }

        [StringLength(3)]
        [JsonProperty("ManufacturingCountryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string COO { get; set; }

        [StringLength(35)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SKUPartNumber { get; set; }

        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Quantity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LandedCostQuantityType QuantityType { get; set; }

        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? UnitPrice { get; set; }

        [StringLength(3)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UnitPriceCurrencyCode { get; set; }

        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? CustomsValue { get; set; }

        [StringLength(3)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CustomsValueCurrencyCode { get; set; }

        /// <summary>
        /// HS Code identifies the item for the Import country to identify the import duty rate for the item.
        /// Can be provided with or without dots
        /// </summary>
        [StringLength(18)]
        [JsonProperty("HarmonizedSystemCode", NullValueHandling = NullValueHandling.Ignore)]
        public string HSCode { get; set; }

        [PositiveDecimal]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ItemWeight { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UnitOfMeasurement ItemWeightUnitofMeasurement { get; set; }

        [StringLength(50)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [StringLength(50)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [Required]
        [ValidateObject]
        public GoodsCharacteristics GoodsCharacteristics { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AdditionalQuantityDefinitions AdditionalQuantityDefinitions { get; set; }


    }
}