using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class BillilngInfo
    {
        /// <summary>
        /// The DHL account number used for the shipment. Used as the shipper account number. Please note if you use this billing section then the above <Account> tag is not needed. <ShipperAccountNumber> is mandatory then
        /// </summary>
        [Required]
        [StringLength(9)]
        [JsonProperty("ShipperAccountNumber")]
        public string ShipperAccount { get; set; }

        /// <summary>
        /// Who will pay for the shipment. If this value is either Receiver or ThirdParty then BillToAccount is required.
        /// </summary>
        [Required]
        [JsonProperty("ShippingPaymentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AccountRole PaiedBy { get; set; }

        /// <summary>
        /// The DHL account number used for the shipment, if ShippingPaymentType is equal to R or T.
        /// </summary>
        [StringLength(9)]
        [JsonProperty("BillingAccountNumber")]
        public string BillToAccount { get; set; }

        public BillilngInfo() { }

        /// <summary>
        /// Initializes a BillingInfo object
        /// </summary>
        /// <param name="billingAccountNumber">Account number which will be billed for this shipment</param>
        /// <param name="shipperAccountNumber">Account number of the shipper</param>
        /// <param name="payer">Who will pay for the shipment (Shipper, Receiver, 3rd party)</param>
        public BillilngInfo(string billingAccountNumber, string shipperAccountNumber, Enums.AccountRole payer)
        {
            this.ShipperAccount = shipperAccountNumber;
            this.PaiedBy = payer;
            this.BillToAccount = billingAccountNumber;
        }
    }
}