using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class ShipmentImage
    {
        [JsonProperty("LabelImageFormat")]
        public string ImageFormat { get; set; }

        [JsonProperty("GraphicImage")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] ImageData { get; set; }

        [JsonProperty("HTMLImage")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] HTMLImage { get; set; }

        public override string ToString()
        {
            return $"Type: {this.ImageFormat}, Filesize: {this.ImageData.Length} bytes";
        }
    }
}