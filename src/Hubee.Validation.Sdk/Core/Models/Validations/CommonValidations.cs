using Hubee.Validation.Sdk.Core.Helpers;
using System.Reflection;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    internal static class CommonValidations
    {
        public static Error IsRequired(PropertyInfo property, object value, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
            {
                return Error.Make($"Property '{property.Name}' is required",
                                  property.Name,
                                  errorCode);
            }

            return null;
        }
    }
}
