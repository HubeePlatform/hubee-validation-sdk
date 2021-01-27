using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class ListValidationTests
    {
        [Fact]
        public void TestValidList()
        {
            var cnpjs = new List<EntityCnpjTest> { new EntityCnpjTest(""), new EntityCnpjTest("") };
            var entity = new EntityListTest(cnpjs).ValidateSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Fact]
        public void TestInvalidList()
        {
            var cnpjs = new List<EntityCnpjTest> { };
            var entity = new EntityListTest(cnpjs).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }

        [Fact]
        public void TestListdAllowEmpty()
        {
            var cnpjs = new List<EntityCnpjTest> { };
            var entity = new EntityEmptyListTest(cnpjs).ValidateSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }
    }
}
