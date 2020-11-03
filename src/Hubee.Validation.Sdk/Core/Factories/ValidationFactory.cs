using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Helpers;
using Hubee.Validation.Sdk.Core.Interfaces;
using Hubee.Validation.Sdk.Core.Models;
using Hubee.Validation.Sdk.Core.Models.Constants;
using Hubee.Validation.Sdk.Core.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hubee.Validation.Sdk.Core.Factories
{
    internal static class ValidationFactory
    {
        public static List<Task> CreateByPropertyName(IValidatableSchema entity,
                                                       PropertyInfo[] properties,
                                                       string propertyName,
                                                       string[] rules,
                                                       ValidationResult result)
        {
            ValidateRulesAndResultObject(rules, result);

            var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName));
            var tasks = new List<Task>();

            ValidateProperty(propertyName, property);
            var propertyValue = property.GetValue(entity);


            foreach (var rule in rules)
            {
                switch (rule)
                {
                    case RuleName.REQUIRED:
                        tasks.Add(new Task(() => result.Add(CommonValidations.IsRequired(property, propertyValue))));
                        break;
                    case string r when r.Contains(RuleName.MIN):
                        tasks.Add(new Task(() => result.Add(CreateValidationForMin(property, propertyValue, rule))));
                        break;
                    case string r when r.Contains(RuleName.MAX):
                        tasks.Add(new Task(() => result.Add(CreateValidationForMax(property, propertyValue, rule))));
                        break;
                    default:
                        throw new RuleNotSupportedException(rule);

                }
            }

            return tasks;
        }

        private static Error CreateValidationForMax(PropertyInfo property, object propertyValue, string rule)
        {
            switch (ValidationHelper.ExtractPropertyTypeName(property))
            {
                case nameof(String):
                    return TextValidations.HasMax(property, propertyValue, rule);
                case nameof(Double):
                case nameof(Decimal):
                case nameof(Int16):
                case nameof(Int32):
                case nameof(Int64):
                    return NumericValidations.HasMax(property, propertyValue, rule);
                default:
                    throw new PropertyTypeNotSupportedForRuleException(property.Name, property.PropertyType.Name, rule);
            }
        }

        private static Error CreateValidationForMin(PropertyInfo property, object propertyValue, string rule)
        {
            switch (ValidationHelper.ExtractPropertyTypeName(property))
            {
                case nameof(String):
                    return TextValidations.HasMin(property, propertyValue, rule);
                case nameof(Double):
                case nameof(Decimal):
                case nameof(Int16):
                case nameof(Int32):
                case nameof(Int64):
                    return NumericValidations.HasMin(property, propertyValue, rule);
                default:
                    throw new PropertyTypeNotSupportedForRuleException(property.Name, property.PropertyType.Name, rule);
            }
        }

        private static void ValidateRulesAndResultObject(string[] rules, ValidationResult result)
        {
            if (rules is null || rules.Length <= 0)
            {
                throw new InvalidOperationException($"Rules can't be empty");
            }

            if (result is null)
            {
                throw new InvalidOperationException($"Object ValidationResult can't be null");
            }
        }

        private static void ValidateProperty(string propertyName, PropertyInfo property)
        {
            if (property is null)
            {
                throw new PropertyNotFoundException(propertyName);
            }
        }
    }
}
