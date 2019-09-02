using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;

namespace MyDHLAPI_REST_Library.Objects.Pickup
{
    public class InternationalDetail
    {
        [ValidateObject]
        public Commodities Commodities { get; set; }
    }
}