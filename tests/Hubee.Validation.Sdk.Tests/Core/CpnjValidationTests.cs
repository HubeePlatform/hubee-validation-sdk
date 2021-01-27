using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class CpnjValidationTests
    {
        [Theory]
        [InlineData("32.944.841/0001-43")]
        [InlineData("25.139.696/0001-62")]
        [InlineData("07874655000138")]
        public void TestValidCnpj(string cnpj)
        {
            var entity = new EntityCnpjTest(cnpj).ValidateSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Theory]
        [InlineData("11111111111111")]
        [InlineData("22222222222222")]
        [InlineData("22.222.222/2222-222")]
        [InlineData("joaojoaojoaojo")]
        public void TestInvalidCnpj(string cnpj)
        {
            var entity = new EntityCnpjTest(cnpj).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }
    }
}
