using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.ePOD {
    public class SenderInfo
    {
        [Required]
        [JsonProperty("@AppCd")]
        // ReSharper disable once StringLiteralTypo
        public string ApplicationCode { get; set; } = "DCGAP";

        [JsonProperty("@AppNm")]
        // ReSharper disable once StringLiteralTypo
        public string ApplicationName { get; set; } = "DCGAP";

        // ReSharper disable once StringLiteralTypo
        [JsonProperty("@CmptNm", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentName { get; set; }

        public override string ToString()
        {
            return $"Name: {ApplicationName}, Code: {ApplicationCode}, Component: {ComponentName ?? "None"}";
        }
    }
}