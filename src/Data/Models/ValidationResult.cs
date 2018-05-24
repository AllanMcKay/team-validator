using System.Collections.Generic;

namespace Data.Models
{
    public class ValidationResult
    {
        public ValidationResult(List<ValidationProblem> errors)
        {
            Errors = errors;
        }
        public bool TeamValid{get{return Errors.Count==0;}}

        public List<ValidationProblem> Errors{get;set;}
    }
}