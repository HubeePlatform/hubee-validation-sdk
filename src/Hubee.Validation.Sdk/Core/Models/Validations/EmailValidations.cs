using Hubee.Validation.Sdk.Core.Helpers;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    public class EmailValidations
    {
        public static Error IsEmail(PropertyInfo property, object value, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var error = Error.Make($"Property '{property.Name}' is not a valid email",
                                  property.Name,
                                  errorCode);

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-!#$&%+*\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(value.ToString()) ? null : error;
        }
    }
}