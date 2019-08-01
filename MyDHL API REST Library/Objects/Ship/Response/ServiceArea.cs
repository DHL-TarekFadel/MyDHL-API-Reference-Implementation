namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class ServiceArea
    {
        public string FacilityCode { get; set; }

        public string ServiceAreaCode { get; set; }

        public string RoutingCode { get; set; }

        public string OutboundSortCode
        {
            set
            {
                RoutingCode = value;
            }
        }

        public string InboundSortCode
        {
            set
            {
                RoutingCode = value;
            }
        }
    }
}