using Hubee.Validation.Sdk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityTextTest: IValidatableSchema
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public List<EntityTextTest> List { get; set; }

        public object GetSchemaRules()
        {
            return new
            {
                Name = "required|min:10|max:100"
            };
        }
    }
}
