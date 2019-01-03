using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Common
{
    public class Common
    {
        public static List<ValidationResult> Validate<T>(ref T obj)
        {
            ValidationContext context = new ValidationContext(obj, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            return results;
        }
    }
}
