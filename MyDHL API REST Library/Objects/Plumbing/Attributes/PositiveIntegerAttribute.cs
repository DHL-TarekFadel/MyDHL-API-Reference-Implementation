using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class PositiveIntegerAttribute : ValidationAttribute
    {
        public PositiveIntegerAttribute()
            : base ("value must be a positive non-zero integer (whole number).")
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (null == value)
            {
                return ValidationResult.Success;
            }

            int val = (int)value;

            if (val > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.MemberName} {ErrorMessage}");
        }
    }
}
