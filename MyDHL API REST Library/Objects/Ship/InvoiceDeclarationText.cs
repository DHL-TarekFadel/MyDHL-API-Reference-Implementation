using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class InvoiceDeclarationText
    {
        [Required]
        [StringLength(300)]
        public string DeclarationText { get; set; }
    }
}