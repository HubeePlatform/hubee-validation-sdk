using System;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class RuleNotSupportedException : Exception
    {
        public RuleNotSupportedException(string rule) : base($"Rule {rule} not supported")
        {

        }
    }
}
