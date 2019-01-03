using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class ShipmentTransaction
    {
        [ValidateObject]
        [JsonProperty("SCDtl")]
        public ShipmentTransactionDetail ShipmentDetail { get; protected set; } = new ShipmentTransactionDetail();

        public ShipmentTransaction(string accountNumber, Enums.EPodCustomerRoleType customerRole, string originCountryCode = "")
        {
            this.ShipmentDetail.AccountNumber = accountNumber;
            this.ShipmentDetail.AccountType = customerRole;
            if (!string.IsNullOrWhiteSpace(originCountryCode))
            {
                this.ShipmentDetail.OriginCountryCode = originCountryCode;
            }
        }
    }
}