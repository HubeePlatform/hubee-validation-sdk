using Hubee.Validation.Sdk.Core.Factories;
using Hubee.Validation.Sdk.Core.Interfaces;
using Hubee.Validation.Sdk.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubee.Validation.Sdk.Core.Extensions
{
    public static class Extensions
    {
        private const int TASK_EXECUTION_TIMEOUT = 20000;

        public static IValidatableSchema ValidadeSchema(this IValidatableSchema validatable)
        {
            validatable.ValidationResult = new ValidationResult();

            var properties = validatable.GetType().GetProperties();

            if (!properties.Any() || (validatable.GetSchemaRules() is null))
                return validatable;

            var rules = validatable.GetSchemaRules();
            var describedValidations = rules.GetType().GetProperties();

            var tasks = new List<Task>();

            foreach (var validation in describedValidations)
            {
                tasks.AddRange(ValidationFactory.CreateByPropertyName(validatable,
                                                                  properties,
                                                                  validation.Name,
                                                                  validation.GetValue(rules)?.ToString().Split('|'),
                                                                  validatable.ValidationResult));
            }

            tasks.ForEach(t => t.Start());

            Task.WaitAll(tasks.ToArray(), TASK_EXECUTION_TIMEOUT);
            return validatable;
        }
    }
}