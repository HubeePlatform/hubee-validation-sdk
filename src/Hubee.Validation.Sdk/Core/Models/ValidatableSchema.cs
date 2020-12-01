using Hubee.Validation.Sdk.Core.Interfaces;

namespace Hubee.Validation.Sdk.Core.Models
{
    public abstract class ValidatableSchema: IValidatableSchema
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract object GetSchemaRules();
    }
}
