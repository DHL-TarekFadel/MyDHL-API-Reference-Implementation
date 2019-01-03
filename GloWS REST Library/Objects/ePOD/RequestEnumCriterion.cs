using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Plumbing.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class RequestEnumCriterion : IRequestCriterion
    {
        public Enums.EPodCriterionType CriterionType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public object CriterionValue { get; set; }

        public RequestEnumCriterion(Enums.EPodCriterionType type, System.Enum value)
        {
            this.CriterionType = type;
            this.CriterionValue = value;
        }
    }
}