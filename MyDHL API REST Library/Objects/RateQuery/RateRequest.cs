using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class RateRequest
    {
        [ValidateObject]
        public ClientDetails ClientDetails { get; set; } = null;

        [ValidateObject]
        public Request Request { get; set; } = new Request();

        [ValidateObject]
        public RequestedShipment RequestedShipment { get; set; }
    }
}
