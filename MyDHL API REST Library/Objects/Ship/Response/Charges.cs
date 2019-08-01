using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class Charges
    {
        [JsonProperty("Charge")]
        public List<Charge> Charge { get; set; }
    }

    public class Charge
    {
        [JsonProperty("ChargeType")]
        public string Type { get; set; }

        [JsonProperty("ChargeAmount")]
        public string Amount { get; set; }
    }
}