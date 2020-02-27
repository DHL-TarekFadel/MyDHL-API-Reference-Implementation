using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class DimensionsCheckAttribute : ValidationAttribute
    {
        private readonly string ThisDimension;
        private readonly string OtherDimension1;
        private readonly string OtherDimension2;

        public DimensionsCheckAttribute(string thisDimension, string otherDimension1, string otherDimension2)
            : base($"{thisDimension} is required if {otherDimension1} or {otherDimension2} are specified")
        {
            this.ThisDimension = thisDimension;
            this.OtherDimension1 = otherDimension1;
            this.OtherDimension2 = otherDimension2;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != value);
            System.Diagnostics.Contracts.Contract.Requires(null != validationContext);

            ErrorMessage = ErrorMessageString;

            int? thisDimensionValue = (int?)value;

            if (null != thisDimensionValue)
            {
                return ValidationResult.Success;
            }

            PropertyInfo otherDimension1Property = validationContext.ObjectType.GetProperty(OtherDimension1);
            PropertyInfo otherDimension2Property = validationContext.ObjectType.GetProperty(OtherDimension2);

            if (null == otherDimension1Property)
            {
                return new ValidationResult($"Unknown property: {OtherDimension1}");
            }

            if (null == otherDimension2Property)
            {
                return new ValidationResult($"Unknown property: {OtherDimension2}");
            }

            int? otherDimensionValue1 = (int?)otherDimension1Property.GetValue(validationContext.ObjectInstance, null);
            int? otherDimensionValue2 = (int?)otherDimension2Property.GetValue(validationContext.ObjectInstance, null);

            if (null != otherDimensionValue1
                || null != otherDimensionValue2)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
