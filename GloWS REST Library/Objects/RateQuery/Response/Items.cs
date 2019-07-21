using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class Items
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Item>))]
        public List<Item> Item { get; set; } = new List<Item>();
    }

    public class Item
    {
        /// <summary>
        /// Item line number
        /// </summary>
        public int ItemNumber { get; set; }

        /// <summary>
        /// Code of the charge
        /// </summary>
        public string ChargeCode { get; set; }

        /// <summary>
        /// Local code of the charge
        /// </summary>
        public string LocalChargeCode { get; set; }

        /// <summary>
        /// Charge type or category
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ItemChargeType ChargeType { get; set; }

        /// <summary>
        /// The charge amount of the line item charge.
        /// </summary>
        public decimal ChargeAmount { get; set; }

        /// <summary>
        /// Name of the charge
        /// </summary>
        public string ChargeName { get; set; }

        /// <summary>
        /// Currency code of the charge
        /// </summary>
        public string ChargeCurrencyCode { get; set; }

        /// <summary>
        /// Special service charge code type for service. XCH type charge codes are Optional Services and should be displayed to users for selection.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ChargeTypeCode ChargeCodeTypeCode { get; set; }

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
    }
}
