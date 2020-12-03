using Hubee.Validation.Sdk.Core.Models;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityGuidTest : ValidatableSchema
    {
        public EntityGuidTest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public override object GetSchemaRules()
        {
            return new
            {
                Id = "guid",
            };
        }
    }

    public class EntityGuidAllowEmptyTest : EntityGuidTest
    {
        public EntityGuidAllowEmptyTest(string id) : base(id) { }

        public override object GetSchemaRules()
        {
            return new
            {
                Id = "guid:allow_empty",
            };
        }
    }
}
