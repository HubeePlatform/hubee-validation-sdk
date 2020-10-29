using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Exceptions
{
    public class PropertyNotFoundException: Exception
    {
        public PropertyNotFoundException(string propertyName) : base ($"Property {propertyName} not found")
        {

        }
    }
}
