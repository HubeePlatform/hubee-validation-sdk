﻿using Hubee.Validation.Sdk.Core.Models;
using System.Text.Json.Serialization;

namespace Hubee.Validation.Sdk.Core.Interfaces
{
    public interface IValidatableSchema
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
        public string ValidationHashCode { get; }
        object GetSchemaRules();
        internal bool ChangedHashCode();
        internal void SetHashCode();
    }
}
