using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentTransactionDetail
    {
        /// <summary>
        /// DHL Account Number: optional for summary ePOD, mandatory for detail ePOD
        /// </summary>
        [StringLength(12)]
        [JsonProperty("@AccNo", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Customer role type code: This code identifies weather the specified account number was used in the Payer, Receiver or Shipper Account field while creating the shipment.
        /// </summary>
        [JsonProperty("@CRlTyCd", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.EPodCustomerRoleType? AccountType { get; set; }

        /// <summary>
        /// Shipment origin country code
        /// </summary>
        [JsonProperty("@CtryCd", NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(2, MinimumLength = 2)]
        public string OriginCountryCode { get; set; }
    }
}