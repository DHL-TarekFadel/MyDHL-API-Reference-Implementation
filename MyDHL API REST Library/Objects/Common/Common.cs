using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Common
{
    public static class Common
    {
        public static List<ValidationResult> Validate<T>(ref T requestObject)
        {
            ValidationContext context = new ValidationContext(requestObject, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(requestObject, context, results, true);

            return results;
        }
    }
}
