using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.Ship.Response
{
    public class ShipmentImage
    {
        [JsonProperty("LabelImageFormat")]
        public string ImageFormat { get; set; }

        [JsonProperty("GraphicImage")]
        public byte[] ImageData { get; set; }

        public override string ToString()
        {
            return $"Type: {this.ImageFormat}, Filesize: {this.ImageData.Length} bytes";
        }
    }
}