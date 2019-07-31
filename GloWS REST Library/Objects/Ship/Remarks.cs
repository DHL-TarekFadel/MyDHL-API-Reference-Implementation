using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class Remarks
    {
        [ValidateObject]
        [CollectionLength(3, 1)]
        public List<Remark> Remark { get; set; }
    }
}