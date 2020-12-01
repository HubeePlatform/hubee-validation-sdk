using Hubee.Validation.Sdk.Core.Helpers;
using System;
using System.Reflection;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    public static class GuidValidations
    {
        private const string _messageError = "Property {0} with the value {1} is not a valid guid";

        public static Error IsGuid(PropertyInfo property, object value, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            return IsValid(value) && (value.ToString() != Guid.Empty.ToString())
                ? null
                : Error.Make(string.Format(_messageError, property.Name, value.ToString()),
                                  property.Name,
                                  errorCode);
        }

        public static Error IsGuidAllowEmpty(PropertyInfo property, object value, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            return IsValid(value)
                ? null
                : Error.Make(string.Format(_messageError, property.Name, value.ToString()),
                                  property.Name,
                                  errorCode);
        }

        private static bool IsValid(object value)
        {
            return Guid.TryParse(value.ToString(), out _);
        }
    }
}
