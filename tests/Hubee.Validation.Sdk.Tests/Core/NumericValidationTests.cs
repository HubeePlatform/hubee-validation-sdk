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
            new object[] { "75a3abb4-8331-4ca7-a12a-295a30b2acb5", 1, 10.1m, 1.55},
            new object[] { "75a3abb4-8331-4ca7-a12a-295a30b2acb5", 1, 50m, 52.55},
            new object[] { "51812201-4c6a-4708-b7de-ec128e0f8710", 1, 24.53m, 15.2 }
        };

        public static IEnumerable<object[]> InvalidNumericData => new List<object[]>
        {
            new object[] { "75a3abb4", 2, 10.0m, 1.54},
            new object[] { "75a3abb483314ca7a12a295a30b2acb5", 3, 51m, 53.55},
            new object[] { "518122014c6a-4708-b7de-ec128e0f8710", - 1, -5.11m, -15.2}
        };


        [Theory]
        [MemberData(nameof(ValidNumericData))]
        public void TestValidNumericObject(string id, int number, decimal value, double price)
        {
            var entity = new EntityNumericTest { Id = id, Number = number, Price = price, Value = value };

            var result = entity.ValidadeSchema();

            Assert.True(result.IsValid());
        }

        [Theory]
        [MemberData(nameof(InvalidNumericData))]
        public void TestInvalidNumericObject(string id, int number, decimal value, double price)
        {
            var entity = new EntityNumericTest { Id = id, Number = number, Price = price, Value = value };

            var result = entity.ValidadeSchema();

            Assert.True(result.IsInvalid());
        }
    }
}
