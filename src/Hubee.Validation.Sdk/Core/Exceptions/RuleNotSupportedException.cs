using System;
using System.Collections.Generic;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class RuleNotSupportedException : Exception
    {
        public RuleNotSupportedException(string rule) : base($"Rule {rule} not supported")
        {

        }
    }
}
