using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class InvoiceSignatureDetails
    {
        [StringLength(35)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureName { get; set; }

        [StringLength(35)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureTitle { get; set; }

        [MaxLength(1000000)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte[] SignatureImage { get; set; }
    }
}