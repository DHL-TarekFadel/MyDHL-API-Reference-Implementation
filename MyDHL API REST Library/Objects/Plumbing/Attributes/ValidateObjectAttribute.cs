using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.Attributes
{
    public class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (null == value)
            {
                //results.Add(new ValidationResult($"{validationContext.DisplayName} cannot be null."));
                return ValidationResult.Success;
            }
            else
            {
                ValidationContext context;
                
                try
                {
                    ICollection coll = value as ICollection;

                    foreach(var item in coll)
                    {
                        context = new ValidationContext(item, null, null);
                        Validator.TryValidateObject(item, context, results, true);
                    }
                }
                catch (NullReferenceException)
                {
                    context = new ValidationContext(value, null, null);
                    Validator.TryValidateObject(value, context, results, true);
                }                
            }            

            if (results.Count != 0)
            {
                var compositeResults = new CompositeValidationResult(String.Format("Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);

                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }
}
