using GloWS_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Ship
{
    public class InternationalDetail
    {
        [JsonProperty("Commodities")]
        public Commodity Commodities { get; set; }

        [Required]
        [JsonProperty("Content")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentType ShipmentType { get; set; }

        /// <summary>
        /// Export Reference field, appears on label
        /// </summary>
        [StringLength(40)]
        [JsonProperty("ExportReference", NullValueHandling = NullValueHandling.Ignore)]
        public string ExportReference { get; set; }
    }
}