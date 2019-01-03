using GloWS_REST_Library.Objects.Plumbing.Attributes;

namespace GloWS_REST_Library.Objects.Common
{
    public class Request
    {
        [ValidateObject]
        public ServiceHeader ServiceHeader { get; set; }
    }
}
