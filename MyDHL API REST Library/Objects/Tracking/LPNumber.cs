using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class LPNumber
    {
        [CollectionLength(100, 0)]
        public List<string> ArrayOfAWBNumberItem { get; set; } = new List<string>();

        public LPNumber() { }

        public LPNumber(string lpNumber)
        {
            ArrayOfAWBNumberItem.Add(lpNumber);
        }

        public LPNumber(IEnumerable<string> lpNumbers)
        {
            ArrayOfAWBNumberItem.AddRange(lpNumbers);
        }
    }
}
