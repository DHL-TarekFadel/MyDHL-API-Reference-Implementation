using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Plumbing.Attributes;

namespace GloWS_REST_Library.Objects.RateQuery
{
    public class RateRequest
    {
        [ValidateObject]
        public ClientDetails ClientDetails { get; set; } = null;

        [ValidateObject]
        public RequestedShipment RequestedShipment { get; set; }
    }
}
