using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;

namespace MyDHLAPI_REST_Library.Objects.Common
{
    public class Request
    {
        [ValidateObject]
        public ServiceHeader ServiceHeader { get; set; }
    }
}
