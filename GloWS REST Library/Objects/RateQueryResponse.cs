using System.Collections.Generic;
using System.Linq;
using MyDHLAPI_REST_Library.Objects.RateQuery.Response;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects {
    public class RateQueryResponse {
        public RateResponse RateResponse { get; set; }

        [JsonIgnore]
        public List<Service> Services => RateResponse.Provider.First().Service;
    }
}
