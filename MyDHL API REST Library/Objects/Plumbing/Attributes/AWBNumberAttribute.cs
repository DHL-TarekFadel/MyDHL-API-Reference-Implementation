using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    /// <summary>
    /// Validates AWB Numbers to ensure that they are the correct length and check out
    /// </summary>
    public class AWBNumberAttribute : ValidationAttribute
    {
        public AWBNumberAttribute()
            : base("AWB Number {0} is not valid.")
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (value is List<string>)
            {
                // Multiple AWB numbers
                Dictionary<string, bool> results = new Dictionary<string, bool>();
                foreach(string item in (List<string>) value)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        results.Add(item, ValidateAWBValue(item));
                    }                    
                }

                if (results.Any(r => !r.Value))
                {
                    // We have errors
                    return new ValidationResult(string.Format(System.Globalization.CultureInfo.InvariantCulture, ErrorMessage, string.Join(", ", results.Where(r => !r.Value).Select(r => r.Key))));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                // Single AWB number
                string awbNumber = (string)value;
                if (string.IsNullOrWhiteSpace(awbNumber))
                {
                    return ValidationResult.Success;
                }

                if (ValidateAWBValue(awbNumber))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(string.Format(System.Globalization.CultureInfo.InvariantCulture, ErrorMessage, awbNumber));
            }
        }

        public static bool ValidateAWBValue(string testValue)
        {
            if(null == testValue)
            {
                return false;
            }

            try
            {
                string waybillValue = testValue.Substring(0, 9);
                string checkDigit = testValue.Substring(9);

                int waybillNumericValue = int.Parse(waybillValue, System.Globalization.CultureInfo.InvariantCulture);
                int checkDigitNumericValue = int.Parse(checkDigit, System.Globalization.CultureInfo.InvariantCulture);

                var quotient = System.Math.DivRem(waybillNumericValue, 7, out int result);

                return result == checkDigitNumericValue;
            }
            catch
            {
                return false;
            }
        }
    }
}
