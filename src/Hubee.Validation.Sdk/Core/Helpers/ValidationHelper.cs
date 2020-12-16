using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Models.Constants;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Hubee.Validation.Sdk.Core.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsValueNullOrEmpty(object value)
        {
            return
                value is null ||
                value.ToString().Equals(string.Empty) ||
                (TypeofHelper.IsList(value) && ReflectionHelper.GetCount(value) <= 0);
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

        public static string ExtractRuleSpecificationValue(string rule)
        {
            var ruleSplitted = rule?.Split(':');

            if (ruleSplitted != null && ruleSplitted.Length > 1)
            {
                var specification = ruleSplitted[1];
                var specifications = typeof(RuleSpecificationName).GetAllConstantValues<string>();

                if (!specifications.Any(s => s.Equals(specification)))
                    throw new RuleInvalidFormatException(rule);

                return specification;
            }

            return rule;
        }
    }
}
