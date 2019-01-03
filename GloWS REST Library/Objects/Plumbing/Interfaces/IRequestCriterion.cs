using GloWS_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloWS_REST_Library.Objects.Plumbing.Interfaces
{
    public interface IRequestCriterion
    {
        [JsonProperty("@TyCd")]
        [JsonConverter(typeof(StringEnumConverter))]
        Enums.EPodCriterionType CriterionType { get; set; }

        [JsonProperty("@Val")]
        object CriterionValue { get; set; }
    }
}
