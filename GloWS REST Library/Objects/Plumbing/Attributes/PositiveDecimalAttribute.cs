using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class PositiveDecimalAttribute : ValidationAttribute
    {
        public PositiveDecimalAttribute()
            : base("Value must be a positive non-zero number.")
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (decimal) value;

            if (currentValue > 0.0M)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
