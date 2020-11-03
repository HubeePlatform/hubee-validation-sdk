using System;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class RuleInvalidFormatException : Exception
    {
        public RuleInvalidFormatException(string rule) : base($"Invalid format for rule {rule}")
        {

        }
    }
}
