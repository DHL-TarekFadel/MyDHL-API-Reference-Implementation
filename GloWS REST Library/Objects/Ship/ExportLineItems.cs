using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ExportLineItems
    {
        [ValidateObject]
        [CollectionLength(999, 1)]
        public List<ExportLineItem> ExportLineItem { get; set; }
    }
}