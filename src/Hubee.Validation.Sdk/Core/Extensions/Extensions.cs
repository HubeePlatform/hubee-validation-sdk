using Hubee.Validation.Sdk.Core.Factories;
using Hubee.Validation.Sdk.Core.Interfaces;
using Hubee.Validation.Sdk.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubee.Validation.Sdk.Core.Extensions
{
    public static class Extensions
    {
        private const int TASK_EXECUTION_TIMEOUT = 20000;
        public static ValidationResult ValidadeSchema(this IValidatableSchema validatable)
        {
            var properties = validatable.GetType().GetProperties();
            var rules = validatable.GetSchemaRules();
            var describedValidations = rules.GetType().GetProperties();
            var validationResult = new ValidationResult();

            var tasks = new List<Task>();

            foreach (var validation in describedValidations)
            {
                tasks.AddRange(ValidationFactory.CreateByPropertyName(validatable,
                                                                  properties,
                                                                  validation.Name,
                                                                  validation.GetValue(rules)?.ToString().Split('|'),
                                                                  validationResult));
            }

            tasks.ForEach(t => t.Start());

            Task.WaitAll(tasks.ToArray(), TASK_EXECUTION_TIMEOUT);
            return validationResult;
        }
    }
}
