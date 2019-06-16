using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class AWBNumber
    {
        [AWBNumber]
        public List<string> ArrayOfAWBNumberItem { get; set; } = new List<string>();

        public AWBNumber() { }

        public AWBNumber (string awbNumber)
        {
            ArrayOfAWBNumberItem.Add(awbNumber);
        }

        public AWBNumber (IEnumerable<string> awbNumbers)
        {
            ArrayOfAWBNumberItem.AddRange(awbNumbers);
        }
    }
}
