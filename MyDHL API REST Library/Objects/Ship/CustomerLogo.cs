using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class CustomerLogo
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is a special case where a byte array is expected.")]
        public byte[] LogoImage { get; set; }

        [JsonProperty("LogoImageFormat")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LogoImageFormat LogoFormat { get; set; }

        public CustomerLogo() { }

        public CustomerLogo(byte[] logoImage, Enums.LogoImageFormat logoFormat)
        {
            this.LogoImage = logoImage;
            this.LogoFormat = logoFormat;
        }

        public CustomerLogo(byte[] logoImage, string logoMimeType)
        {
            Enums.LogoImageFormat? logoFormat = null;
            switch (logoMimeType)
            {
                case ("image/png"):
                    logoFormat = Enums.LogoImageFormat.PNG;
                    break;
                case ("image/jpg"):
                case ("image/jpeg"):
                    logoFormat = Enums.LogoImageFormat.JPEG;
                    break;
                case ("image/gif"):
                    logoFormat = Enums.LogoImageFormat.GIF;
                    break;
            }

            this.LogoImage = logoImage;
            this.LogoFormat = logoFormat.Value;
        }


    }
}