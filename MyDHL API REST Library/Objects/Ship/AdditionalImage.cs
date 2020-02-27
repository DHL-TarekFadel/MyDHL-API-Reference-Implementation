using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class AdditionalImage
    {
        [JsonProperty("DocumentImageType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdditionalImageType? ImageType { get; set; }

        [Required]
        [JsonProperty("DocumentImage")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] ImageContent { get; set; }

        [JsonProperty("DocumentImageFormat", NullValueHandling = NullValueHandling.Ignore)]
        public Enums.AdditionalImageFormat? ImageFormat { get; set; }

        public AdditionalImage(byte[] imageContent, Enums.AdditionalImageFormat? imageFormat, Enums.AdditionalImageType? imageType)
        {
            this.ImageContent = imageContent;
            this.ImageFormat = imageFormat;
            this.ImageType = imageType;
        }

        public AdditionalImage(byte[] imageContent, string imageMimeType, Enums.AdditionalImageType? imageType)
        {
            Enums.AdditionalImageFormat? imageFormat = null;
            switch (imageMimeType)
            {
                case ("application/pdf"):
                    imageFormat = Enums.AdditionalImageFormat.PDF;
                    break;
                case ("image/tiff"):
                    imageFormat = Enums.AdditionalImageFormat.TIFF;
                    break;
                case ("image/png"):
                    imageFormat = Enums.AdditionalImageFormat.PNG;
                    break;
                case ("image/jpg"):
                case ("image/jpeg"):
                    imageFormat = Enums.AdditionalImageFormat.JPEG;
                    break;
                case ("image/gif"):
                    imageFormat = Enums.AdditionalImageFormat.GIF;
                    break;
            }

            this.ImageContent = imageContent;
            this.ImageFormat = imageFormat.Value;
            this.ImageType = imageType;
        }
    }
}