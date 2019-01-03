using GloWS_REST_Library.Objects.Plumbing.Attributes;
using GloWS_REST_Library.Objects.Plumbing.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using static GloWS_REST_Library.Objects.Common.Enums;

namespace GloWS_REST_Library.Objects.ePOD
{
    public class RequestCriteria
    {
        [ValidateObject]
        [JsonProperty("GenrcRqCritr")]
        public List<IRequestCriterion> RequestCriterions { get; protected set; }

        public RequestCriteria()
        {
            this.RequestCriterions = new List<IRequestCriterion>()
            {
                new RequestStringCriterion(EPodCriterionType.ImageFormat, "PDF")
                , new RequestStringCriterion(EPodCriterionType.IsRenderDocument, "true")
                , new RequestStringCriterion(EPodCriterionType.DuplicateHandling, "CORE_WB_NO")
                , new RequestStringCriterion(EPodCriterionType.SortBy, "$INGEST_DATE,D")
                , new RequestStringCriterion(EPodCriterionType.Language, "en")
            };
        }
    }
}