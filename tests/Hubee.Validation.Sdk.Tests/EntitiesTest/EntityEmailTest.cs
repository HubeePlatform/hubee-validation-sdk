using Hubee.Validation.Sdk.Core.Models;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityEmailTest : ValidatableSchema
    {
        public EntityEmailTest(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public override object GetSchemaRules()
        {
            return new
            {
                Email = "required|email",
            };
        }
    }
}
