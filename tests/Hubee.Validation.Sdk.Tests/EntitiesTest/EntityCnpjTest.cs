using Hubee.Validation.Sdk.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityCnpjTest : ValidatableSchema
    {
        public string Cnpj { get; private set; }

        public EntityCnpjTest(string cnpj)
        {
            Cnpj = cnpj;
        }

        public override object GetSchemaRules()
        {
            return new
            {
                Cnpj = "required|cnpj"
            };
        }
    }
}
