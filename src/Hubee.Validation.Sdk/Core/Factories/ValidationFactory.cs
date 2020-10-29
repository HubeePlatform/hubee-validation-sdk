using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Interfaces;
using Hubee.Validation.Sdk.Core.Models;
using Hubee.Validation.Sdk.Core.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
                if (rule.Equals("required"))
                {
                    tasks.Add(new Task(() => result.Add(CommonValidation.IsRequired(property, propertyValue))));
                    continue;
                }

                if (rule.Contains("min"))
                {
                    tasks.Add(new Task(() => result.Add(CreateValidationForMin(property, propertyValue, rule))));
                    continue;
                }

                if (rule.Contains("max"))
                {
                    tasks.Add(new Task(() => result.Add(CreateValidationForMax(property, propertyValue, rule))));
                    continue;
                }

                throw new RuleNotSupportedException(rule);

            }

            return tasks;
        }

        private static Error CreateValidationForMax(PropertyInfo property, object propertyValue, string rule)
        {
            switch (property.PropertyType.Name)
            {
                case nameof(String):
                    return TextValidations.HasMaxLen(property, propertyValue, rule);
                default:
                    throw new PropertyTypeNotSupportedForRuleException(property.Name, property.PropertyType.Name, rule);
            }
        }

        private static Error CreateValidationForMin(PropertyInfo property, object propertyValue, string rule)
        {
            switch (property.PropertyType.Name)
            {
                case nameof(String):
                    return TextValidations.HasMinLen(property, propertyValue, rule);

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
