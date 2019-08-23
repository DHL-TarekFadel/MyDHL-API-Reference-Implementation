using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentTransaction
    {
        /// <summary>
        /// Pickup Date-Time: <b>We recommend not to enter the pick up date.</b>
        /// </summary>
        [JsonProperty("@PuDtm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-ddT00:00:00")]
        public DateTime? PickupDateTime { get; set; }

        [ValidateObject]
        [JsonProperty("SCDtl", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentTransactionDetail ShipmentDetail { get; set; }

        public ShipmentTransaction() { }

        public ShipmentTransaction(string accountNumber, Enums.EPodCustomerRoleType customerRole, string originCountryCode = "")
        {
            this.ShipmentDetail = new ShipmentTransactionDetail
            {
                AccountNumber = accountNumber,
                AccountType = customerRole
            };

            if (!string.IsNullOrWhiteSpace(originCountryCode))
            {
                this.ShipmentDetail.OriginCountryCode = originCountryCode;
            }
        }
    }
}