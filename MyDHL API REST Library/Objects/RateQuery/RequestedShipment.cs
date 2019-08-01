using System;
using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class RequestedShipment {

        /// <summary>
        /// This element is to provide clients with options to see DHL products and services without price.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? GetRateEstimate { get; set; }

        /// <summary>
        /// The option to receive breakdown of charges including taxes and discounts
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? GetDetailedRateBreakdown { get; set; }

        /// <summary>
        /// To show charges in other currencies, when set to "Y" BILLC, PULCL and BASEC (billing currency, country public rates currency, and base currency respectively) will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? IncludeAdditionalCurrencies { get; set; }

        /// <summary>
        /// RegularPickup: The pickup location is already served by a regular courier and an additional pickup does not need to be considered for this service.
        /// RequestCourier: The rating response returns products for which the pickup capability is given, based on ShipmentTimeStamp.
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DropOffType DropOffType { get; set; }

        /// <summary>
        /// Keep trying subsequent days until a valid capability/quote is found (up to 10 days in the future)?
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? NextBusinessDay { get; set; }

        /// <summary>
        /// Shipper/Consignee information
        /// </summary>
        [Required]
        [ValidateObject]
        public Ship Ship { get; set; }

        /// <summary>
        /// Packages/Shipment pieces
        /// </summary>
        [ValidateObject]
        public Packages Packages { get; set; }

        /// <summary>
        /// This timestamp identifies the ready date and time of the rated shipment.
        /// </summary>
        [Required]
        // ReSharper disable once StringLiteralTypo
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-ddTHH:mm:ss GMTzzz")]
        public DateTime ShipTimestamp { get; set; }

        /// <summary>
        /// For future use in DCT
        /// </summary>
        [StringLength(26)]
        [JsonIgnore]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PickupLocationCloseTime { get; set; }

        /// <summary>
        /// The unit of measurement for the weights and dimensions of the shipment.
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UnitOfMeasurement UnitOfMeasurement { get; set; }

        /// <summary>
        /// Dutiable/non-dutiable
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentType Content { get; set; }

        /// <summary>
        /// Customs declared value
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? DeclaredValue { get; set; }

        [StringLength(3)]
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("DeclaredValueCurrecyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string DeclaredValueCurrencyCode { get; set; }

        /// <summary>
        /// Terms of Trade
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Enums.TermsOfTrade? PaymentInfo { get; set; }

        /// <summary>
        /// The DHL account number that is used for the shipment. If used, please do not pass the Billing element as well
        /// </summary>
        [StringLength(12, MinimumLength = 8)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Account { get; set; }

        /// <summary>
        /// The country code of the payer. This field is to allow rate requests with no account number provided.
        /// 
        /// This special function needs to be enabled for your username by your DHL Express IT Consultant.
        /// </summary>
        [StringLength(2, MinimumLength = 2)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PayerCountryCode { get; set; }

        /// <summary>
        /// How will this shipment be billed (use Account if shipper will be paying)
        /// </summary>
        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Billing Billing { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SpecialServices SpecialServices { get; set; }

        /// <summary>
        /// Yes: all the additional services available for the product selected will be returned (default No)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? RequestValueAddedServices { get; set; } = Enums.YesNo.No;

        /// <summary>
        /// DHL Product Code used to ship the items
        /// </summary>
        [StringLength(1, MinimumLength = 1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceType { get; set; }

        /// <summary>
        /// DHL “local / country specific” Product Code used to ship the items
        /// </summary>
        [StringLength(1, MinimumLength = 1)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LocalServiceType { get; set; }

        /// <summary>
        /// The NetworkTypeCode field is used to filter facility network type code.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.NetworkTypeCode? NetworkTypeCode { get; set; }

        /// <summary>
        /// Customer agreement indicator for product and services
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? CustomerAgreementInd { get; set; }

        /// <summary>
        /// Validate ready time against pickup window start on DDI products
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? ValidateReadyTime { get; set; }

    }
}