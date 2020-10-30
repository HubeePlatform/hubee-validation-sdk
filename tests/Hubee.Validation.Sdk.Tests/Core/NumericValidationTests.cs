using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using System.Collections.Generic;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class NumericValidationTests
    {

        public static IEnumerable<object[]> ValidNumericData => new List<object[]>
        {
            new object[] { 1, 10.1m, 1.55},
            new object[] { 1, 50m, 52.55},
            new object[] { 1, 24.53m, 15.2 }
        };

        public static IEnumerable<object[]> InvalidNumericData => new List<object[]>
        {
            new object[] { 2, 10.0m, 1.54},
            new object[] { 3, 51m, 53.55},
            new object[] { -1, -5.11m, -15.2}
        };


        [Theory]
        [MemberData(nameof(ValidNumericData))]
        public void TestValidNumericObject(int number, decimal value, double price)
        {
            var entity = new EntityNumericTest { Number = number, Price = price, Value = value };

            var result = entity.ValidadeSchema();

            Assert.True(result.IsValid());
        }

        [Theory]
        [MemberData(nameof(InvalidNumericData))]
        public void TestInvalidNumericObject(int number, decimal value, double price)
        {
            var entity = new EntityNumericTest { Number = number, Price = price, Value = value };

            var result = entity.ValidadeSchema();

            Assert.True(result.IsInvalid());
        }
    }
}
