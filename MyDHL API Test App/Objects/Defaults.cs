using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDHLAPI_Test_App.Objects
{
    public class Defaults
    {
        public string ShipperAccountNumber { get; set; }

        public string BillingAccountNumber { get; set; }

        public string DutyAccountNumber { get; set; }

        public DefaultAddress From { get; set; }

        public DefaultAddress To { get; set; }

        public decimal? DeclaredValue { get; set; }

        public string DeclaredCurrency { get; set; }

        public string ShipmentContents { get; set; }

        public string ShipmentReference { get; set; }

        public List<DefaultPiece> Pieces { get; set; }

        public string TrackingAWBNumber { get; set; }

        public DefaultEPOD EPOD { get; set; }

        public Insurance Insurance { get; set; }

        public CoD CoD { get; set; }
    }
}
