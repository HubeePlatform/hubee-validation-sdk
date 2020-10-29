using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hubee.Validation.Sdk.Core.Models
{
    public class ValidationResult
    {
        private readonly ConcurrentQueue<Error> errors;

        public ValidationResult()
        {
            errors = new ConcurrentQueue<Error>();
        }

        public void Add(Error error)
        {
            if (error is null)
                return;

            errors.Enqueue(error);
        }

        public List<Error> GetErrors()
        {
            return errors.ToList();
        }

        public bool IsValid()
        {
            return !errors.Any();
        }

        public bool IsInvalid()
        {
            return errors.Any();
        }

        public IList<string> StringifyAsList()
        {
            var result = new List<string>();

            errors.ToList().ForEach(error => result.Add(error.ToString()));

            return result;
        }

        public string Stringify()
        {
            var builder = new StringBuilder();

            errors.ToList().ForEach(error => builder.AppendLine(error.ToString()));

            return builder.ToString();
        }
    }
}
