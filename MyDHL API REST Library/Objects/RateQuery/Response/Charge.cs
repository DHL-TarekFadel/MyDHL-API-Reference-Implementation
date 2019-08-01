using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response {
    public class Charge {
        public string ChargeCode { get; set; }

        public string LocalChargeCode { get; set; }

        public string ChargeType { get; set; }

        public decimal? ChargeAmount { get; set; }

        public string ChargeName { get; set; }

        public string ChargeCurrencyCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeTypeCode? ChargeCodeTypeCode { get; set; }

        /// <summary>
        /// Indicator if there is any discount allowed 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? BillingServiceInd { get; set; }

        /// <summary>
        /// Customer agreement indicator for product and services, if service is offered with prior customer agreement
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? CustomerAgreementInd { get; set; }

        /// <summary>
        /// Indicator if the special service is marketed service
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? MarketedServiceInd { get; set; }

        public ChargeBreakdown ChargeBreakdown { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{ChargeType} : {ChargeAmount}";
        }
    }
}