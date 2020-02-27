using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class CollectionLengthAttribute : ValidationAttribute
    {
        private readonly int MinLength;
        private readonly int MaxLength;

        public CollectionLengthAttribute(int maxLength, int minLength = 0)
            : base($"should have between {minLength} and {maxLength} elements (inclusive).")
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != value);
            System.Diagnostics.Contracts.Contract.Requires(null != validationContext);

            ErrorMessage = $"{validationContext.DisplayName} {ErrorMessageString}";

            if (0 == MinLength && null == value)
            {
                return ValidationResult.Success;
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

            return null == collection 
                   || collection.Count < MinLength
                   || collection.Count > MaxLength
                   ? new ValidationResult(ErrorMessage)
                   : ValidationResult.Success;
        }
    }
}
