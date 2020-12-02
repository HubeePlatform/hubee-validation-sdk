using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Core.Interfaces;

namespace Hubee.Validation.Sdk.Core.Models
{
    public abstract class ValidatableSchema : IValidatableSchema
    {
        private ValidationResult validationResult;

        public ValidationResult ValidationResult
        {
            get
            {
                if (validationResult is null)
                    this.ValidadeSchema();

                return validationResult;
            }
            set
            {
                validationResult = value;
            }
        }

        public abstract object GetSchemaRules();
    }
}
