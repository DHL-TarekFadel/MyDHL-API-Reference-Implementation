using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class InvoiceDeclarationTexts
    {
        [ValidateObject]
        [CollectionLength(3, 1)]
        public List<InvoiceDeclarationText> InvoiceDeclarationText { get; set; }
    }
}