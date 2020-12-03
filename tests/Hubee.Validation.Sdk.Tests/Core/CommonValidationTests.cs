using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class CommonValidationTests
    {
        [Fact]
        public void TestRequiredWithInvalidObject()
        {
            var entity = new EntityCommonTest("", null, null, null).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(4, entity.ValidationResult.GetErrors().Count);
        }

        [Fact]
        public void TestRequiredWithValidObject()
        {
            var entity = new EntityCommonTest("João", 0, DateTime.Now, 2).ValidateSchema();

            for (int x = 0; x < 100000; x++)
            {
                entity.ValidateSchema();

                Assert.True(entity.ValidationResult.IsValid());
            }
        }

        [Fact]
        public void TestInvalidPropertyNameShouldThrowException()
        {
            var entity = new InvalidPropertyEntityTest("João", 0, DateTime.Now, 0);

            Assert.Throws<PropertyNotFoundException>(() => { entity.ValidateSchema(); });
        }

        [Fact]
        public void TestInvalidRuleShouldThrowException()
        {
            var entity = new InvalidRuleEntityTest("João", 0, DateTime.Now, 0 );

            Assert.Throws<RuleNotSupportedException>(() => { entity.ValidateSchema(); });
        }

        [Fact]
        public void TestAutoValidation()
        {
            var entity = new EntityCommonTest("", null, null, null);

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(4, entity.ValidationResult.GetErrors().Count);

            entity.CreatedDate = DateTime.Now;
            entity.Name = "Luiz";

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(2, entity.ValidationResult.GetErrors().Count);

            entity.Value = 2;
            entity.Stock = 0;

            Assert.True(entity.ValidationResult.IsValid());
            Assert.Empty(entity.ValidationResult.GetErrors());
        }
    }
}
