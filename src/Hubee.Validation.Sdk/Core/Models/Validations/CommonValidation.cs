using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    internal static class CommonValidation
    {
        public static Error IsRequired(PropertyInfo property, object value, string errorCode = null)
        {
            if (value is null || value.ToString().Equals(string.Empty))
            {
                return Error.Make($"Property '{property.Name}' is required",
                                  property.Name,
                                  errorCode);
            }

            return null;
        }
    }
}
