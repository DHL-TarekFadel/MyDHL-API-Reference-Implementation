using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Exceptions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "This is a special Exception which requires additional data to be present.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "This is a special Exception which requires additional data to be present.")]
    public class MyDHLAPIValidationException : Exception
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

        /// <summary>
        /// Pretty prints validation errors
        /// </summary>
        /// <param name="results">Validation errors to print</param>
        /// <param name="indentationLevel">Number of spaces to indent child errors</param>
        /// <returns>Pretty printed validation errors</returns>
        public static string PrintResults(IEnumerable<ValidationResult> results, int indentationLevel = 0)
        {
            if (null == results)
            {
                throw new ArgumentNullException(nameof(results));
            }

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
