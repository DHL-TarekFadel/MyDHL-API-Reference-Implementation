using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class GlobalID
    {
        [JsonProperty("@Id")]
        public string ReferenceId { get; set; }

        [JsonProperty("@IdTp")]
        public string ReferenceIdType { get; set; }

        public override string ToString()
        {
            return $"{this.ReferenceIdType}: {this.ReferenceId}";
        }
    }
}