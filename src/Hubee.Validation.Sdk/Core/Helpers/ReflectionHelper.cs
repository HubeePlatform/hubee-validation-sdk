using System.Collections;

namespace Hubee.Validation.Sdk.Core.Helpers
{
    public static class ReflectionHelper
    {
        public static int GetCount(object value)
        {
            if (value is null) return 0;
            var property = typeof(ICollection).GetProperty("Count");
            return (int)property.GetValue(value, null);
        }
    }
}