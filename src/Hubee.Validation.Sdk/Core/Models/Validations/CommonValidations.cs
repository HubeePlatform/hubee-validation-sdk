using System.Reflection;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    internal static class CommonValidations
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
