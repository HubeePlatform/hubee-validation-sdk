using Hubee.Validation.Sdk.Core.Models;
using System;
using System.Collections.Generic;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityCommonTest : ValidatableSchema
    {
        public EntityCommonTest(string name, int? stock, DateTime? createdDate, decimal? value, IList<string> listValue)
        {
            Name = name;
            Stock = stock;
            CreatedDate = createdDate;
            Value = value;
            ListValue = listValue;
        }

        public string Name { get; set; }
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Value { get; set; }
        public IList<string> ListValue { get; set; }
        public override object GetSchemaRules()
        {
            return new
            {
                Name = "required",
                Stock = "required",
                CreatedDate = "required",
                Value = "required",
                ListValue = "required"
            };
        }
    }

    public class InvalidPropertyEntityTest : EntityCommonTest
    {
        public InvalidPropertyEntityTest(string name, int? stock, DateTime? createdDate, decimal? value, IList<string> listValue) : base(name, stock, createdDate, value, listValue) { }

        public override object GetSchemaRules()
        {
            return new
            {
                Name = "required",
                Stock = "required",
                CreatedDate = "required",
                Value = "required",
                ListValue = "required",
                InexistentProperty = "required"
            };
        }
    }

    public class InvalidRuleEntityTest : EntityCommonTest
    {
        public InvalidRuleEntityTest(string name, int? stock, DateTime? createdDate, decimal? value, IList<string> listValue) : base(name, stock, createdDate, value, listValue) { }

        public override object GetSchemaRules()
        {
            return new
            {
                Name = "inexistent-rule",
                Stock = "required",
                CreatedDate = "required",
                Value = "required",
                ListValue = "required",
                InexistentProperty = "required"
            };
        }
    }
}
