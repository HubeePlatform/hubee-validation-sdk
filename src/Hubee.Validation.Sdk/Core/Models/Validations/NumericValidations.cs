﻿using Hubee.Validation.Sdk.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    public class NumericValidations
    {
        public static Error HasMin(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var expected = ValidationHelper.ExtractColonRuleNumericValue(rule);

            if (double.Parse(value.ToString()) < expected)
                return Error.Make($"Property '{property.Name}' must have min value {expected} ", property.Name);

            return null;
        }

        public static Error HasMax(PropertyInfo property, object value, string rule, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var expected = ValidationHelper.ExtractColonRuleNumericValue(rule);

            if (double.Parse(value.ToString()) > expected)
                return Error.Make($"Property '{property.Name}' must have max value {expected}", property.Name);

            return null;
        }
    }
}
