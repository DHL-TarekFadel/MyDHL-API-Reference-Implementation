using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class PositiveDecimalAttribute : ValidationAttribute
    {
        private decimal _minimumValue;

        public PositiveDecimalAttribute()
            : base("Value must be a positive non-zero number.")
        {
            _minimumValue = 0.0M;
        }

        public PositiveDecimalAttribute(string minimumValue)
            : base($"Value must be a positive non-zero number with a minimum value of {decimal.Parse(minimumValue, System.Globalization.CultureInfo.InvariantCulture):#,##0.##}")
        {
            _minimumValue = decimal.Parse(minimumValue, System.Globalization.CultureInfo.InvariantCulture);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (null == value)
            { // This is a nullable decimal, so a null value is a success
                return ValidationResult.Success;
            }

            var currentValue = (decimal) value;
            if (currentValue > _minimumValue)
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
