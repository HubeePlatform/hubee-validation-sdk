using System;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string propertyName) : base($"Property {propertyName} not found")
        {

        }
    }
}
