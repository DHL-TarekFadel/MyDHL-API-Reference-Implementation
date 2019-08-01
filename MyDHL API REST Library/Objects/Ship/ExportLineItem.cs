using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ExportLineItem
    {
        [StringLength(20)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CommodityCode { get; set; }

        /// <summary>
        /// Export Control Classification Number, this is required for EEI filing US country usage.
        /// </summary>
        [StringLength(30)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ECCN { get; set; }

        [JsonProperty("ExportReasonType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ExportReasonType? ExportReason { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ItemNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
               
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.CustomsStatisticalUnitOfMeasurement QuantityUnitOfMeasurement { get; set; }

        [Required]
        [StringLength(60)]
        public string ItemDescription { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal NetWeight { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal GrossWeight { get; set; }

        [StringLength(2)]
        [JsonProperty("ManufacturingCountryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryOfManufacture { get; set; }
    }
}