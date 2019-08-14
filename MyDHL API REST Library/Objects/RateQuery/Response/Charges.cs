using System.Collections.Generic;
using System.Linq;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class Charges {

        [JsonProperty("@type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeType? ChargeType { get; set; }

        public string Currency { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Charge>))]
        public List<Charge> Charge { get; set; } = new List<Charge>();

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Type: {ChargeType} | Currency: {Currency} | # of Charges: {Charge.Count}";
        }

        public bool HasCharge(string chargeCode)
        {
            return Charge.Any(c => c.ChargeCode == chargeCode || c.LocalChargeCode == chargeCode);
        }

        public bool HasCharge(string chargeCode, Enums.ChargeTypeCode chargeTypeCode)
        {
            return Charge.Any(c => (c.ChargeCode == chargeCode || c.LocalChargeCode == chargeCode) && c.ChargeCodeTypeCode == chargeTypeCode);
        }
    }
}