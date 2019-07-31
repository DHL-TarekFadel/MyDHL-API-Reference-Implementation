using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class ChargeBreakdown
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Breakdown>))]
        public List<Breakdown> Breakdown { get; set; } = new List<Breakdown>();
    }

    public class Breakdown
    {

        /// <summary>
        /// If a breakdown is provided, details can either be TAX or DISCOUNT
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Discount or tax type codes as provided by DCT.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The actual amount of the discount/tax
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Percentage of the discount/tax
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// The base amount of the service charge
        /// </summary>
        public decimal? BaseAmount { get; set; }
    }

}
