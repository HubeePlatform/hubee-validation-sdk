using Hubee.Validation.Sdk.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsValueNullOrEmpty(object value)
        {
            return value is null || value.ToString().Equals(string.Empty);
        }

        public static string ExtractPropertyTypeName(PropertyInfo property)
        {
            var propertyTypeName = property.PropertyType.Name;

            if (property.PropertyType.IsGenericType && property.PropertyType.GenericTypeArguments.Length > 0)
            {
                propertyTypeName = property.PropertyType.GenericTypeArguments[0].Name;
            }

            return propertyTypeName;
        }

        public static double ExtractColonRuleNumericValue(string rule)
        {
            var ruleSplitted = rule?.Split(':');

            if (ruleSplitted is null || ruleSplitted.Length < 2)
                throw new RuleInvalidFormatException(rule);                

            try
            {
                return double.Parse(ruleSplitted[1], CultureInfo.GetCultureInfo("en-US").NumberFormat);
            }
            catch
            {
                throw new RuleInvalidFormatException(rule);
            }
           
        }
    }
}
