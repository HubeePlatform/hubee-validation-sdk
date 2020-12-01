using Hubee.Validation.Sdk.Core.Models;

namespace Hubee.Validation.Sdk.Core.Interfaces
{
    public interface IValidatableSchema
    {
        public ValidationResult ValidationResult { get; set; }
        object GetSchemaRules();
    }
}
