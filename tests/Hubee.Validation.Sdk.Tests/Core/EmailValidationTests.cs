using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class EmailValidationTests
    {
        [Theory]
        [InlineData("luiz@gmail.tx")]
        [InlineData("joao@hotmail.tech")]
        [InlineData("alberto_veloso@hubee.com")]
        [InlineData("cleiton@tech.br")]
        [InlineData("cleiton_-+!#$%&*@tech.br")]
        [InlineData("cleiton&@tech.br")]
        public void TestValidEmail(string email)
        {
            var entity = new EntityEmailTest(email).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Theory]
        [InlineData("luiz.gmail.com")]
        [InlineData("joao.com.br")]
        [InlineData("antonio@gmail")]
        [InlineData("beto#gmail.com")]
        [InlineData("luiz¨assis@gmail.com")]
        [InlineData("joao@hubee@gmail.com")]
        public void TestInvalidEmail(string email)
        {
            var entity = new EntityEmailTest(email).ValidadeSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }
    }
}
