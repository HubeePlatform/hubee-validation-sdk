using Hubee.Validation.Sdk.Core.Exceptions;
using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class CommonValidationTests
    {
        [Fact]
        public void TestRequiredWithInvalidObject()
        {
            var entity = new EntityCommonTest() { Name = "", CreatedDate = null, Stock = null, Value = null };

            var result = entity.ValidadeSchema();
            Assert.True(result.IsInvalid());
            Assert.Equal(4, result.GetErrors().Count);
        }

        [Fact]
        public void TestRequiredWithValidObject()
        {
            var entity = new EntityCommonTest() { Name = "João", CreatedDate = DateTime.Now, Stock = 0, Value = 2 };

            for (int x = 0; x < 100000; x++)
            {
                var result = entity.ValidadeSchema();

                Assert.True(result.IsValid());
            }
        }

        [Fact]
        public void TestInvalidPropertyNameShouldThrowException()
        {
            var entity = new InvalidPropertyEntityTest() { Name = "João", CreatedDate = DateTime.Now, Stock = 0, Value = 0 };

            Assert.Throws<PropertyNotFoundException>(() => { entity.ValidadeSchema(); });
        }

        [Fact]
        public void TestInvalidRuleShouldThrowException()
        {
            var entity = new InvalidRuleEntityTest() { Name = "João", CreatedDate = DateTime.Now, Stock = 0, Value = 0 };

            Assert.Throws<RuleNotSupportedException>(() => { entity.ValidadeSchema(); });
        }
    }
}
