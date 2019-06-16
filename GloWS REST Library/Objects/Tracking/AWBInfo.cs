using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class AWBInfo
    {
        [ValidateObject]
        public AWBInfoItem ArrayOfAWBInfoItem { get; set; }
    }
}
