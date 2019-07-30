using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Exceptions
{
    public class MyDHLAPIValidationException : System.Exception
    {
        private const string _msg = "Validation errors were found. Please refer to the Exception data for more information.";

        public MyDHLAPIValidationException(List<ValidationResult> validationResults)
            : base(_msg)
        {
            base.Data.Add("ValidationResults", validationResults);
        }

        public List<ValidationResult> ExtractValidationResults()
        {
            return (List<ValidationResult>) base.Data["ValidationResults"];
        }

        public static string PrintResults(IEnumerable<ValidationResult> results, int indentationLevel = 0)
        {
            string retval = string.Empty;
            string prefix = string.Empty;
            foreach (var validationResult in results)
            {
                retval = $"{prefix}{SetIndentation(indentationLevel)}{validationResult.ErrorMessage}";
                prefix = Environment.NewLine;

                if (validationResult is CompositeValidationResult)
                {
                    retval += $"{Environment.NewLine}{PrintResults(((CompositeValidationResult)validationResult).Results, indentationLevel + 1)}";
                }
            }

            return retval;
        }

        private static string SetIndentation(int indentationLevel)
        {
            return new string(' ', indentationLevel * 2);
        }
    }
}
