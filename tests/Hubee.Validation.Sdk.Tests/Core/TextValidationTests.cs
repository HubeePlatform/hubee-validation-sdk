using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Tests.EntitiesTest;
using Xunit;

namespace Hubee.Validation.Sdk.Tests.Core
{
    public class TextValidationTests
    {
        [Theory]
        [InlineData("João Antonio Bulgareli")]
        [InlineData("Luiz Henrique Miranda de Assis")]
        [InlineData("Alberto Stephanio Veloso")]
        [InlineData("Cleiton Waldemar Ribeiro de Souza")]
        public void TestValidMaxLen(string name)
        {
            var entity = new EntityTextTest(name);

            entity.ValidateSchema();

            Assert.True(entity.ValidationResult.IsValid());
        }

        [Fact]
        public void TestInvalidMaxLen()
        {
            var entity = new EntityTextTest(
                "Pedro de Alcântara Francisco Antônio João Carlos Xavier de Paula Miguel Rafael Joaquim José Gonzaga Pascoal Cipriano Serafim de Bragança e Bourbon"
                ).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }

        [Theory]
        [InlineData("João")]
        [InlineData("Antonio")]
        [InlineData("Bulgareli")]
        public void TestInvalidMinLen(string name)
        {
            var entity = new EntityTextTest(name).ValidateSchema();

            Assert.True(entity.ValidationResult.IsInvalid());
        }
    }
}
