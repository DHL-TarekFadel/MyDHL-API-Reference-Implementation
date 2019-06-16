using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.ePOD
{
    public class RequestStringCriterion : IRequestCriterion
    {
        public Enums.EPodCriterionType CriterionType { get; set; }

        public object CriterionValue { get; set; }

        public RequestStringCriterion(Enums.EPodCriterionType type, string value)
        {
            this.CriterionType = type;
            this.CriterionValue = value;
        }
    }
}