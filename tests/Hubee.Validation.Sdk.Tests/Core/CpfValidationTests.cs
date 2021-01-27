using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class CpfValidationTests
    {
        [Theory]
        [InlineData("344.503.450-88")]
        [InlineData("295.908.390-37")]
        [InlineData("10458142026")]
        public void TestValidCpf(string cpf)
        {
            var entity = new EntityCpfTest(cpf).ValidateSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Theory]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("333.333.333-11")]
        [InlineData("joaojoaojoa")]
        public void TestInvalidCpf(string cpf)
        {
            var entity = new EntityCpfTest(cpf).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }
    }
}
