using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Plumbing.Attributes
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

            if (collection.Count < MinLength
                || collection.Count > MaxLength)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
