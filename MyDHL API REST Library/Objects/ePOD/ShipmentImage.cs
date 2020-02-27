using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ShipmentImage
    {
        [JsonProperty("@ImgMimeTy")]
        public string MimeType { get; set; }

        [JsonProperty("@Img")]
        public string Base64Image { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] Image
        {
            get
            {
                return System.Convert.FromBase64String(Base64Image);
            }
        }
    }
}