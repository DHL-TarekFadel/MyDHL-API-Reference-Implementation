using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class ShipmentMonetaryAmount
    {
        [ValidateObject]
        [CollectionLength(20, 1)]
        public List<ShipmentMonetaryAmountCharges> Charges { get; set; }
    }

    public class ShipmentMonetaryAmountCharges
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LandedCostChargeType ChargeType { get; set; }

        [Required]
        [PositiveDecimal]
        public decimal ChargeAmount { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; }
    }
}