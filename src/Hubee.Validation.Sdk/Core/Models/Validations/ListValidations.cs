using Hubee.Validation.Sdk.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    public class ListValidations
    {
        private const string _messageError = "Property {0} with the value {1} is not a valid list";

        public static Error IsList(PropertyInfo property, object value, string errorCode = null)
        {
            if (value is null)
                return null;

            return IsValid(value) && (value as IEnumerable).Cast<object>().Any()
                ? null
                : Error.Make(string.Format(_messageError, property.Name, value.ToString()),
                                  property.Name,
                                  errorCode);
        }

        public static Error IsListAllowEmpty(PropertyInfo property, object value, string errorCode = null)
        {
            if (value is null)
                return null;

            return IsValid(value)
                ? null
                : Error.Make(string.Format(_messageError, property.Name, value.ToString()),
                                  property.Name,
                                  errorCode);
        }

        private static bool IsValid(object value)
        {
            return value is IList &&
                   value.GetType().IsGenericType &&
                   value.GetType()
                        .GetGenericTypeDefinition()
                        .IsAssignableFrom(typeof(List<>));
        }
    }
}
