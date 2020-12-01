using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class GuidValidationTests
    {
        [Theory]
        [InlineData("75a3abb4-8331-4ca7-a12a-295a30b2acb5")]
        [InlineData("6ac3e2cc-17a0-4a0b-9d8d-12d0ed64d95f")]
        public void TestValidGuid(string id)
        {
            var entity = new EntityGuidTest(id).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        [InlineData("75a3abb483314ca7a12a295a30b2acb5addd")]
        [InlineData("75a3abb4")]
        public void TestInvalidGuid(string id)
        {
            var entity = new EntityGuidTest(id).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        [InlineData("6ac3e2cc-17a0-4a0b-9d8d-12d0ed64d95f")]
        public void TestGuidAllowEmpty(string id)
        {
            var entity = new EntityGuidAllowEmptyTest(id).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }
    }
}
