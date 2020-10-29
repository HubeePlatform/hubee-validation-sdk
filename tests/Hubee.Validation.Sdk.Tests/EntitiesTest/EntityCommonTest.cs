using Hubee.Validation.Sdk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityCommonTest : IValidatableSchema
    {
        public string Name { get; set; }
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Value { get; set; }
        public virtual object GetSchemaRules()
        {
            return new
            {
                Name = "required",
                Stock = "required|min:1",
                CreatedDate = "required",
                Value = "required|max:1"
            };
        }
    }

    public class InvalidPropertyEntityTest: EntityCommonTest
    {
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

    public class InvalidRuleEntityTest: EntityCommonTest
    {
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
