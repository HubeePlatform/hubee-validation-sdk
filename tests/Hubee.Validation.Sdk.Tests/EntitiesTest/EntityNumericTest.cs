using Hubee.Validation.Sdk.Core.Interfaces;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityNumericTest : IValidatableSchema
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public double Price { get; set; }

        public object GetSchemaRules()
        {
            return new
            {
                Id = "required|guid",
                Number = "required|min:1|max:1",
                Value = "required|min:10.1|max:50",
                Price = "required|min:1.55|max:52.55"
            };
        }
    }
}
