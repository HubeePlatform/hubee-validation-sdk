using Hubee.Validation.Sdk.Core.Models;
using System;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityCommonTest : ValidatableSchema
    {
        public EntityCommonTest(string name, int? stock, DateTime? createdDate, decimal? value)
        {
            Name = name;
            Stock = stock;
            CreatedDate = createdDate;
            Value = value;
        }

        public string Name { get; set; }
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Value { get; set; }
        public override object GetSchemaRules()
        {
            return new
            {
                Name = "required",
                Stock = "required",
                CreatedDate = "required",
                Value = "required"
            };
        }
    }

    public class InvalidPropertyEntityTest : EntityCommonTest
    {
        public InvalidPropertyEntityTest(string name, int? stock, DateTime? createdDate, decimal? value) : base(name, stock, createdDate, value) { }

        public override object GetSchemaRules()
        {
            return new
            {
                Name = "required",
                Stock = "required",
                CreatedDate = "required",
                Value = "required",
                InexistentProperty = "required"
            };
        }
    }

    public class InvalidRuleEntityTest : EntityCommonTest
    {
        public InvalidRuleEntityTest(string name, int? stock, DateTime? createdDate, decimal? value) : base(name, stock, createdDate, value) { }

        public override object GetSchemaRules()
        {
            return new
            {
                Name = "inexistent-rule",
                Stock = "required",
                CreatedDate = "required",
                Value = "required",
                InexistentProperty = "required"
            };
        }
    }
}
