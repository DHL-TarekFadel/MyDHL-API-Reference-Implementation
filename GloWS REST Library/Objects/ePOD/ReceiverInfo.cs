using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class ReceiverInfo
    {
        [JsonProperty("@AppNm")]
        public string ApplicationName { get; set; }

        [JsonProperty("@AppCd")]
        public string ApplicationCode { get; set; }

        [JsonProperty("GId")]
        public GlobalID GID { get; set; }

        public override string ToString()
        {
            return $"Name: {ApplicationName}, Code: {ApplicationCode}, GID: ({GID})";
        }
    }
}