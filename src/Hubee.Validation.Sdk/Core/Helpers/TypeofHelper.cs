using System.Collections.Generic;

namespace Hubee.Validation.Sdk.Core.Helpers
{
    public static class TypeofHelper
    {
        public static bool IsList(object value)
        {
            if (value is null) return false;
            return value.GetType().IsGenericType &&
                   value.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
    }
}