using Hubee.Validation.Sdk.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityListTest : ValidatableSchema
    {
        public IList<EntityCnpjTest> MyList { get; set; }

        public EntityListTest(IList<EntityCnpjTest> myList)
        {
            MyList = myList;
        }

        public override object GetSchemaRules()
        {
            return new
            {
                MyList = "list"
            };
        }
    }

    public class EntityEmptyListTest : ValidatableSchema
    {
        public IList<EntityCnpjTest> MyList { get; set; }

        public EntityEmptyListTest(IList<EntityCnpjTest> myList)
        {
            MyList = myList;
        }

        public override object GetSchemaRules()
        {
            return new
            {
                MyList = "list:allow_empty"
            };
        }
    }
}
