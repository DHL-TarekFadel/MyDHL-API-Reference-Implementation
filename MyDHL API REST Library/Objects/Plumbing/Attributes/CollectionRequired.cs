using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class CollectionRequiredAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = string.Format(ErrorMessageString, validationContext.MemberName);

            if (null == value)
            {
                return new ValidationResult(ErrorMessage);
            }

            Type type = value.GetType();

            ICollection collection;
            try
            {
                collection = value as ICollection;
            }
            catch
            {
                return new ValidationResult($"{validationContext.DisplayName} is of the wrong type.");
            }

            if (collection.Count <= 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
