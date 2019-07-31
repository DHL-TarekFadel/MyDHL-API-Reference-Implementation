using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ShipmentPrepaidTotalCharge
    {
        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = "CASH";
    }
}