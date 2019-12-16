using System;
using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class Service {
        [JsonProperty("@type")]
        public string ProductCode { get; set; }

        public ProductCharges TotalNet { get; set; }

        public Charges Charges { get; set; }

        public TotalChargeTypes TotalChargeTypes { get; set; }

        public Items Items { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DeliveryTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DeliveryType? DeliveryType { get; set; }

        /// <summary>
        /// This is the cutoff time for the service offered in the response.  This represents the latest time (local to origin) which the shipment can be tendered to the courier for that service on that day.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CutoffTime { get; set; }

        /// <summary>
        /// Pickup cut off time in GMT HH:MM:SS
        /// </summary>
        public string CutoffTimeGMT { get; set; }

        public string CutoffTimeOffset { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? NextBusinessDayInd { get; set; }

        /// <summary>
        /// The DHL earliest time possible for pickup 
        /// </summary>
        public string PickupWindowEarliestTime { get; set; }

        /// <summary>
        /// The DHL latest time possible for pickup
        /// </summary>
        public string PickupWindowLatestTime { get; set; }

        /// <summary>
        /// Local service name 
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// DHL “local / country specific” Product Code used to ship the items. Optional and applicable only to get Landed Cost
        /// </summary>
        public string LocalServiceType { get; set; }

        /// <summary>
        /// The country code for the local service used
        /// </summary>
        public string LocalServiceCountryCode { get; set; }

        /// <summary>
        /// The NetworkTypeCode element indicates the product belongs to the Day Definite (DD) or Time Definite (TD) network.
        /// </summary>
        public Enums.NetworkTypeCode? NetworkTypeCode { get; set; }

        /// <summary>
        /// Indicator that the product only can be offered to customers with prior agreement.
        /// </summary>
        public Enums.YesNo? CustomerAgreementInd { get; set; }

        /// <summary>
        /// The number of transit days
        /// </summary>
        public int? TotalTransitDays { get; set; }

        /// <summary>
        /// This is additional transit delays (in days) for shipment picked up from the mentioned city or postal area to arrival at the service area.
        /// </summary>
        public int? PickupAdditionalDays { get; set; }

        /// <summary>
        /// This is additional transit delays (in days) for shipment delivered to the mentioned city or postal area following arrival at the service area.
        /// </summary>
        public int? DeliveryAdditionalDays { get; set; }

        /// <summary>
        /// The dimensional weight of the shipment
        /// </summary>
        public decimal? VolumetricWeight { get; set; }

        /// <summary>
        /// The quoted weight of the shipment
        /// </summary>
        public decimal? QuotedWeight { get; set; }

        /// <summary>
        /// The unit of measurement for the dimensions of the package.
        /// </summary>
        public Enums.UnitOfMeasurement? UnitOfMeasurement { get; set; }

        /// <summary>
        /// Pickup day of the week number
        /// </summary>
        public int? PickupDayOfWeek { get; set; }

        /// <summary>
        /// Destination day of the week number
        /// </summary>
        public int? DestinationDayOfWeek { get; set; }

        /// <summary>
        /// The date when the rates for DHL products and services is provided
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? PricingDate { get; set; }

        public ServiceArea OriginServiceArea { get; set; }

        public ServiceArea DestinationServiceArea { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Product: {ProductCode}, Price: {TotalNet.Currency} {TotalNet.Amount:#,##0.00}";
        }
    }
}