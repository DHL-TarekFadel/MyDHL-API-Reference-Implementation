using System;

namespace MyDHLAPI_Test_App.Objects
{
    public class SuccessfulPickupRequest
    {
        public DateTime PickupDate { get; set; }

        public string PickupCountry { get; set; }

        public string PickupRequestNumber { get; set; }

        public string RequestorName { get; set; }
    }
}
