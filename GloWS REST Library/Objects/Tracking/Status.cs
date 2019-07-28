using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class Status
    {
        public string ActionStatus { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [ValidateObject]
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        [ValidateObject]
        [JsonConverter(typeof(SingleOrArrayConverter<ConditionItem>))]
        public List<ConditionItem> ArrayOfConditionItem { get; set; }
    }

    public class ConditionItem
    {
        public string ConditionCode { get; set; }

        public string ConditionData { get; set; }
    }
}