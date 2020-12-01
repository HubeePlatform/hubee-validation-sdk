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
            var entity = new EntityCommonTest("", null, null, null).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
            Assert.Equal(4, entity.ValidationResult.GetErrors().Count);
        }

        [Fact]
        public void TestRequiredWithValidObject()
        {
            var entity = new EntityCommonTest("João", 0, DateTime.Now, 2).ValidadeSchema();

            for (int x = 0; x < 100000; x++)
            {
                entity.ValidadeSchema();

                Assert.True(entity.ValidationResult.IsValid());
            }
        }

        [Fact]
        public void TestInvalidPropertyNameShouldThrowException()
        {
            var entity = new InvalidPropertyEntityTest("João", 0, DateTime.Now, 0);

            Assert.Throws<PropertyNotFoundException>(() => { entity.ValidadeSchema(); });
        }

        [Fact]
        public void TestInvalidRuleShouldThrowException()
        {
            var entity = new InvalidRuleEntityTest("João", 0, DateTime.Now, 0 );

            Assert.Throws<RuleNotSupportedException>(() => { entity.ValidadeSchema(); });
        }
    }
}
