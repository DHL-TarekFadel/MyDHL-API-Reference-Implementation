using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class TotalChargeTypes
    {
        [JsonProperty("@type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeType? ChargeType { get; set; }

        public string Currency { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<TotalChargeType>))]
        public List<TotalChargeType> TotalChargeType { get; set; } = new List<TotalChargeType>();
    }

    public class TotalChargeType
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.TotalChargeType Type { get; set; }

        /// <summary>
        /// The amount price of DHL product and services
        /// </summary>
        public decimal Amount { get; set; }
    }
}
