using Hubee.Validation.Sdk.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Tests.EntitiesTest
{
    public class EntityCpfTest : ValidatableSchema
    {
        public string Cpf { get; private set; }

        public EntityCpfTest(string cpf)
        {
            Cpf = cpf;
        }

        public override object GetSchemaRules()
        {
            return new
            {
                Cpf = "required|cpf"
            };
        }
    }
}
