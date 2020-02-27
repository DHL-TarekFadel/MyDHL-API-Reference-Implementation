using System;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class IntegerBetweenAttribute : ValidationAttribute
    {
        internal int _Minimum;
        internal int _Maximum;

        public IntegerBetweenAttribute(int minimum, int maximum)
            : base($"Integer value must be between {minimum} and {maximum} (inclusive).")
        {
            this._Minimum = minimum;
            this._Maximum = maximum;
        }

        protected IntegerBetweenAttribute(int minimum, int maximum, Func<string> errorMessageAccessor)
            : base(errorMessageAccessor)
        {
            this._Minimum = minimum;
            this._Maximum = maximum;
        }

        protected IntegerBetweenAttribute(int minimum, int maximum, string errorMessage)
            : base(errorMessage)
        {
            this._Minimum = minimum;
            this._Maximum = maximum;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (null == value)
            {
                return ValidationResult.Success;
            }

            int val = (int) value;

            if (val >= this._Minimum && val <= this._Maximum)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
