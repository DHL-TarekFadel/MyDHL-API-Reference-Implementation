using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class BillingInfo
    {
        /// <summary>
        /// The DHL account number used for the shipment. Used as the shipper account number. Please note if you use this billing section then the above <Account> tag is not needed. <ShipperAccountNumber> is mandatory then
        /// </summary>
        [Required]
        [StringLength(12)]
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
        [StringLength(12)]
        [JsonProperty("BillingAccountNumber")]
        public string BillToAccount { get; set; }

        /// <summary>
        /// The DHL account number used for Duties & Taxes.
        /// </summary>
        [StringLength(12)]
        [JsonProperty("DutyAndTaxPayerAccountNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string DutyAndTaxPayerAccountNumber { get; set; }

        /// <summary>
        /// The NeverOverrideBillingServices is an optional flag to indicate whether to override the DHL Billing Service should it be incorrectly provided. This is automatically derived based on the Shipper/Receiver Address, Shipper/Payer Account number and type of shipment.
        /// </summary>
        [JsonProperty("NeverOverrideBillingService", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? NeverOverrideBillingService { get; set; }

        [ValidateObject]
        [JsonProperty("ShipmentPrepaidTotalCharge", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentPrepaidTotalCharge ShipmentPrepaidTotalCharge { get; set; }

        public BillingInfo() { }

        /// <summary>
        /// Initializes a BillingInfo object
        /// </summary>
        /// <param name="billingAccountNumber">Account number which will be billed for this shipment</param>
        /// <param name="shipperAccountNumber">Account number of the shipper</param>
        /// <param name="payer">Who will pay for the shipment (Shipper, Receiver, 3rd party)</param>
        public BillingInfo(string billingAccountNumber
                            , string shipperAccountNumber
                            , Enums.AccountRole payer
                            , string dutyAccountNumber = ""
                            , bool overrideBillingService = true)
        {
            this.ShipperAccount = shipperAccountNumber;
            this.PaiedBy = payer;
            this.BillToAccount = billingAccountNumber;
            this.DutyAndTaxPayerAccountNumber = (string.IsNullOrWhiteSpace(dutyAccountNumber) ? null : dutyAccountNumber);
            this.NeverOverrideBillingService = (overrideBillingService ? Enums.YesNo.No : Enums.YesNo.Yes);
        }
    }
}