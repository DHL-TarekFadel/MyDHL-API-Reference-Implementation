using GloWS_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class ShipmentTransactionDetail
    {
        [Required]
        [StringLength(12)]
        [JsonProperty("@AccNo")]
        public string AccountNumber { get; set; }

        [JsonProperty("@CRlTyCd")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.EPodCustomerRoleType AccountType { get; set; }

        [JsonProperty("@CtryCd", NullValueHandling = NullValueHandling.Ignore)]
        [StringLength(2, MinimumLength = 2)]
        public string OriginCountryCode { get; set; }
    }
}