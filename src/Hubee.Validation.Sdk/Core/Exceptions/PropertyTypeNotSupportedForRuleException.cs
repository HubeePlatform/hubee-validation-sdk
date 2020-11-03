using System;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class PropertyTypeNotSupportedForRuleException : Exception
    {
        public PropertyTypeNotSupportedForRuleException(string propertyName,
                                                        string typeName,
                                                        string rule) : base($"Rule {rule} is'nt supported for type {typeName} on property {propertyName}")
        {

        }
    }
}
