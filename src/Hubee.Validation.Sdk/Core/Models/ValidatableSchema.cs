using Hubee.Validation.Sdk.Core.Extensions;
using Hubee.Validation.Sdk.Core.Helpers;
using Hubee.Validation.Sdk.Core.Interfaces;
using System.Linq;
using System.Text.Json.Serialization;

namespace Hubee.Validation.Sdk.Core.Models
{
    public abstract class ValidatableSchema : IValidatableSchema
    {
        protected ValidatableSchema() => this.ValidationHashCode = string.Empty;

        private ValidationResult validationResult;

        [JsonIgnore]
        public ValidationResult ValidationResult
        {
            get
            {
                if (ChangedValidationHashCode())
                    this.ValidateSchema();

                return validationResult;
            }
            set
            {
                validationResult = value;
            }
        }

        public string ValidationHashCode { get; private set; }

        public abstract object GetSchemaRules();

        bool IValidatableSchema.ChangedHashCode()
        {
            return ChangedValidationHashCode();
        }

        void IValidatableSchema.SetHashCode()
        {
            this.ValidationHashCode = HashCode;
        }

        private string HashCode
        {
            get
            {
                var rules = this.GetSchemaRules()?.GetType()?.GetProperties();
                var entity = this;

                if (rules is null || entity is null)
                    return string.Empty;

                var rulesName = rules.Select(x => x.Name).ToList();
                var properties = entity.GetType().GetProperties();

                var entityNamespace = entity.ToString();
                var propertiesValues = properties.Where(x => rulesName.Contains(x.Name)).OrderBy(x => x.Name).Select(x => x.GetValue(entity)).ToList();

                var key = $"{entityNamespace}:{string.Join(",", propertiesValues.ToArray())}";
                return CryptographyHelper.CreateMD5Hash(key);
            }
        }

        private bool ChangedValidationHashCode()
        {
            return !this.ValidationHashCode.Equals(HashCode);
        }
    }
}