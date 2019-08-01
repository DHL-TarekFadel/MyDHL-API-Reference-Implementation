using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;

namespace MyDHLAPI_REST_Library.Objects.Common {
    public class Weight {
        [Required]
        [PositiveDecimal]
        public decimal Value { get; set; }
    }
}
