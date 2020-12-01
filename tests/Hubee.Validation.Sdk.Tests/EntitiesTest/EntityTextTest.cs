using Hubee.Validation.Sdk.Core.Models;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityTextTest : ValidatableSchema
    {
        public EntityTextTest(string name, string alias = "")
        {
            Name = name;
            Alias = alias;
        }

        public string Name { get; set; }
        public string Alias { get; set; }
        public override object GetSchemaRules()
        {
            return new
            {
                Name = "required|min:10|max:100"
            };
        }
    }
}
