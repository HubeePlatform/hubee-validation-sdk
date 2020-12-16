using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class CommonValidationTests
    {
        [Fact]
        public void TestRequiredWithInvalidObject()
        {
            var entity = new EntityCommonTest("", null, null, null, null).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(5, entity.ValidationResult.GetErrors().Count);
        }

        [Fact]
        public void TestRequiredWithValidObject()
        {
            var entity = new EntityCommonTest("João", 0, DateTime.Now, 2, new List<string> { "João" }).ValidateSchema();

            for (int x = 0; x < 100000; x++)
            {
                entity.ValidateSchema();

                Assert.True(entity.ValidationResult.IsValid());
            }
        }

        [Fact]
        public void TestInvalidPropertyNameShouldThrowException()
        {
            var entity = new InvalidPropertyEntityTest("João", 0, DateTime.Now, 0, null);

            Assert.Throws<PropertyNotFoundException>(() => { entity.ValidateSchema(); });
        }

        [Fact]
        public void TestInvalidRuleShouldThrowException()
        {
            var entity = new InvalidRuleEntityTest("João", 0, DateTime.Now, 0, null);

            Assert.Throws<RuleNotSupportedException>(() => { entity.ValidateSchema(); });
        }

        [Fact]
        public void TestAutoValidation()
        {
            var entity = new EntityCommonTest("", null, null, null, new List<string> { });

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(5, entity.ValidationResult.GetErrors().Count);

            entity.CreatedDate = DateTime.Now;
            entity.Name = "Luiz";

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(3, entity.ValidationResult.GetErrors().Count);

            entity.Value = 2;
            entity.Stock = 0;
            entity.ListValue = new List<string> { "Luiz" };

            Assert.True(entity.ValidationResult.IsValid());
            Assert.Empty(entity.ValidationResult.GetErrors());
        }
    }
}
