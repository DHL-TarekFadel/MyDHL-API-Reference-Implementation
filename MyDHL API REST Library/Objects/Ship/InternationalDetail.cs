using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class InternationalDetail
    {
        [Required]
        [JsonProperty("Content")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentType ShipmentType { get; set; }

        [ValidateObject]
        [JsonProperty("Commodities")]
        public Commodity Commodities { get; set; }

        [ValidateObject]
        [JsonProperty("ExportDeclaration", NullValueHandling = NullValueHandling.Ignore)]
        public ExportDeclaration ExportDeclaration { get; set; }

        ///// <summary>
        ///// Export Reference field, appears on label
        ///// </summary>
        //[StringLength(40)]
        //[JsonProperty("ExportReference", NullValueHandling = NullValueHandling.Ignore)]
        //public string ExportReference { get; set; }

    }
}