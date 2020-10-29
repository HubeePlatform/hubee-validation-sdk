using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    internal static class TextValidations
    {
        public static Error HasMinLen(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var expected = ValidationHelper.ExtractColonRuleIntegerValue(rule);

            if (value.ToString().Length < expected)
                return Error.Make($"Property {property.Name} must have {expected} min length", property.Name);

            return null;
        }

        public static Error HasMaxLen(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;
 
            var expected = ValidationHelper.ExtractColonRuleIntegerValue(rule);

            if (value.ToString().Length > expected)
                return Error.Make($"Property {property.Name} must have {expected} max length", property.Name);

            return null;
        }
    }
}
