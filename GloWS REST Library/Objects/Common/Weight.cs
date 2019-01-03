using System.ComponentModel.DataAnnotations;
using GloWS_REST_Library.Objects.Plumbing.Attributes;

namespace GloWS_REST_Library.Objects.Common {
    public class Weight {
        [Required]
        [PositiveDecimal]
        public decimal Value { get; set; }
    }
}
