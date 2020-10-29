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
        public static Error HasMin(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var expected = ValidationHelper.ExtractColonRuleNumericValue(rule);

            if (value.ToString().Length < expected)
                return Error.Make($"Property '{property.Name}' must have min length {expected} ", property.Name);

            return null;
        }

        public static Error HasMax(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;
 
            var expected = ValidationHelper.ExtractColonRuleNumericValue(rule);

            if (value.ToString().Length > expected)
                return Error.Make($"Property '{property.Name}' must have max length {expected}", property.Name);

            return null;
        }
    }
}
