namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class ServiceArea
    {
        public string FacilityCode { get; set; }

        public string ServiceAreaCode { get; set; }

        public string RoutingCode { get; set; }

        private string _outboundSortCode;
        public string OutboundSortCode
        {
            get
            {
                return _outboundSortCode;
            }
            set
            {
                RoutingCode = value;
                _outboundSortCode = value;
            }
        }

        private string _inboundSortCode;
        public string InboundSortCode
        {
            get
            {
                return _inboundSortCode;
            }
            set
            {
                RoutingCode = value;
                _inboundSortCode = value;
            }
        }
    }
}