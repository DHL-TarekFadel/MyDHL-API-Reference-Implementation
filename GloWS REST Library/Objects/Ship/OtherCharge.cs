using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class OtherCharge
    {
        [Required]
        public string Caption { get; set; }

        [Required]
        public decimal ChargeValue { get; set; }
    }
}