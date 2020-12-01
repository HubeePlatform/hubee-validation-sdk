using Hubee.Validation.Sdk.Core.Models;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityNumericTest : ValidatableSchema
    {
        public EntityNumericTest(int number, decimal value, double price)
        {
            Number = number;
            Value = value;
            Price = price;
        }

        public int Number { get; set; }
        public decimal Value { get; set; }
        public double Price { get; set; }

        public override object GetSchemaRules()
        {
            return new
            {
                Number = "required|min:1|max:1",
                Value = "required|min:10.1|max:50",
                Price = "required|min:1.55|max:52.55"
            };
        }
    }
}
