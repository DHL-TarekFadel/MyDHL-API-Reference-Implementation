using MyDHLAPI_REST_Library.Objects.Tracking;
using System;
using System.ComponentModel.DataAnnotations;


namespace MyDHLAPI_Test_App.Objects
{
    public class TrackingEventData
    {
        [Display(Name = "#")]
        public string TrackingNumber { get; set; } // AWB # | Piece ID

        [Display(Name = "Code")]
        public string Code { get; set; } // Checkpoint Code

        [Display(Name = "Description")]
        public string Description { get; set; } //Checkpoint description

        [Display(Name = "S.A.")]
        public string ServiceAreaCode { get; set; }

        [Display(Name = "S.A. Name")]
        public string ServiceAreaName { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; } // Checkpoint date

        /// <summary>
        /// Builds a tracking event object
        /// </summary>
        /// <param name="awbNumber">AWB #
        /// <param name="sEvent">Shipment Event object</param>        
        public TrackingEventData(string awbNumber, com.dhl.wsbexpress.track.ShipmentEvent sEvent)
        {
            this.TrackingNumber = awbNumber;
            this.Code = sEvent.ServiceEvent.EventCode;
            if (this.Code == "OK" && null != sEvent.Signatory)
            {
                this.Description = $"{sEvent.ServiceEvent.Description} - SIGNED FOR BY: {sEvent.Signatory}";
            }
            else
            {
                this.Description = sEvent.ServiceEvent.Description;
            }
            this.Date = sEvent.Date.Date + sEvent.Time.TimeOfDay;
            this.ServiceAreaCode = sEvent.ServiceArea.ServiceAreaCode;
            this.ServiceAreaName = sEvent.ServiceArea.Description;
        }

        /// <summary>
        /// Builds a tracking event object
        /// </summary>
        /// <param name="pieceID">Piece ID of the shipment</param>
        /// <param name="pEvent">Piece Event object</param>
        public TrackingEventData(string pieceID, com.dhl.wsbexpress.track.PieceEvent pEvent)
        {
            this.TrackingNumber = pieceID;
            this.Code = pEvent.ServiceEvent.EventCode;
            if (this.Code == "OK" && null != pEvent.Signatory)
            {
                this.Description = $"{pEvent.ServiceEvent.Description} - SIGNED FOR BY: {pEvent.Signatory}";
            }
            else
            {
                this.Description = pEvent.ServiceEvent.Description;
            }
            this.Date = pEvent.Date.Date + pEvent.Time.TimeOfDay;
            this.ServiceAreaCode = pEvent.ServiceArea.ServiceAreaCode;
            this.ServiceAreaName = pEvent.ServiceArea.Description;
        }

        /// <summary>
        /// Builds a tracking event object
        /// </summary>
        /// <param name="awbNumber">AWB #
        /// <param name="event">Shipment Event object</param>        
        public TrackingEventData(string awbNumber, EventItem @event)
        {
            this.TrackingNumber = awbNumber;
            this.Code = @event.ServiceEvent.EventCode;
            if (this.Code == "OK" && null != @event.Signatory)
            {
                this.Description = $"{@event.ServiceEvent.Description} - SIGNED FOR BY: {@event.Signatory}";
            }
            else
            {
                this.Description = @event.ServiceEvent.Description;
            }
            this.Date = @event.Date.Date + @event.Time;
            this.ServiceAreaCode = @event.ServiceArea.ServiceAreaCode;
            this.ServiceAreaName = @event.ServiceArea.Description;
        }
    }
}
