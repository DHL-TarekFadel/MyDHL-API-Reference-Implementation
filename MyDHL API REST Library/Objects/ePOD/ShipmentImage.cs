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
        public byte[] Image
        {
            get
            {
                return System.Convert.FromBase64String(Base64Image);
            }
        }
    }
}