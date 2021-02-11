using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Utilities
{
    public static class ValidationTool
    {
        public static ValidationResult Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            return result;
        }
    }
}
