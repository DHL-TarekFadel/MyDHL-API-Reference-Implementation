using GloWS_REST_Library.Objects.Common;
using System.ComponentModel.DataAnnotations;

namespace GloWS_REST_Library.Objects.Plumbing.Attributes
{
    public class AccountNumberRequiredIfAttribute : ValidationAttribute
    {
        private readonly string FieldToValidate;
        private readonly bool UseFieldName = false;

        public AccountNumberRequiredIfAttribute(string fieldToValidate)
            : base("is required for the selected payment type")
        {
            FieldToValidate = fieldToValidate;
            UseFieldName = true;
        }

        protected AccountNumberRequiredIfAttribute(string errorMessage, string fieldToValidate)
            : base(errorMessage)
        {
            FieldToValidate = fieldToValidate;
            UseFieldName = false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (UseFieldName)
            {
                ErrorMessage = $"{validationContext.DisplayName} {ErrorMessageString}";
            }
            else
            {
                ErrorMessage = ErrorMessageString;
            }

            string accountNumber = (string)value;
            System.Reflection.PropertyInfo otherFieldProperty = validationContext.ObjectType.GetProperty(FieldToValidate);

            if (null == otherFieldProperty)
            {
                return new ValidationResult($"Unknown property: {FieldToValidate}");
            }

            Enums.PaymentTypes otherField = (Enums.PaymentTypes)otherFieldProperty.GetValue(validationContext.ObjectInstance, null);

            switch (FieldToValidate)
            {
                case "ShippingPaymentType":
                    if (otherField != Enums.PaymentTypes.Shipper
                        && string.IsNullOrWhiteSpace(accountNumber))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    break;
            }

            return ValidationResult.Success;
        }
    }
}
