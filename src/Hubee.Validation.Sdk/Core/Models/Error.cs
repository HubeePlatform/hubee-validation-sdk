using System;

namespace Hubee.Validation.Sdk.Core.Models
{
    public class Error
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        public string Property { get; set; }

        public static Error Make(string message, string property, string code = null)
        {
            return new Error(message, property, code);
        }

        public Error(string message, string property, string code = null)
        {
            if (message is null)
            {
                throw new ArgumentNullException($"Parameter {nameof(message)} can't be null");
            }

            Message = message;
            Code = code;
            Property = property;
        }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(Code) ? $"[{Code}] " + Message : Message;
        }
    }
}
