using Hubee.Validation.Sdk.Core.Interfaces;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityEmailTest : IValidatableSchema
    {
        public string Email { get; set; }

        public object GetSchemaRules()
        {
            return new
            {
                Email = "required|email",
            };
        }
    }
}
