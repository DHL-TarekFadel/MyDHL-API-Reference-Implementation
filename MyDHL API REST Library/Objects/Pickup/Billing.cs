using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class Billing
    {
        [StringLength(9)]
        public string ShipperAccountNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PaymentTypes ShippingPaymentType { get; set; }

        [StringLength(9)]
        public string BillingAccountNumber { get; set; }

        public Billing() { }

        public Billing(string shipperAccountNumber, Enums.PaymentTypes paymentType, string billingAccountNumber = "")
        {
            this.ShipperAccountNumber = shipperAccountNumber;
            this.ShippingPaymentType = paymentType;

            if (string.IsNullOrWhiteSpace(billingAccountNumber))
            {
                this.BillingAccountNumber = this.ShipperAccountNumber;
            }
        }
    }
}