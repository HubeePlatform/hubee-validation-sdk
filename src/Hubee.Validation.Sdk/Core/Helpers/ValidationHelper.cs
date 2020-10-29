using Hubee.Validation.Sdk.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsValueNullOrEmpty(object value)
        {
            return value is null || value.ToString().Equals(string.Empty);
        }

        public static int ExtractColonRuleIntegerValue(string rule)
        {
            var ruleSplitted = rule?.Split(':');

            if (ruleSplitted is null || ruleSplitted.Length < 2)
                throw new RuleInvalidFormatException(rule);

            if (!ruleSplitted[1].All(char.IsDigit))
                throw new RuleInvalidFormatException(rule);

            return int.Parse(ruleSplitted[1]);
        }
    }
}
