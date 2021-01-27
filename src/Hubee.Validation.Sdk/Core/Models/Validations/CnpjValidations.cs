using Hubee.Validation.Sdk.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Hubee.Validation.Sdk.Core.Models.Validations
{
    public static class CnpjValidations
    {
        public static Error IsCnpj(PropertyInfo property, object value, string errorCode = null)
        {
            if (ValidationHelper.IsValueNullOrEmpty(value))
                return null;

            var error = Error.Make($"Property '{property.Name}' is not a valid CNPJ",
                                  property.Name,
                                  errorCode);

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var cnpj = Convert.ToString(value);

            cnpj = Regex.Replace(cnpj, "[^0-9]", "");


            if (cnpj.Length != 14)
                return error;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito) ? null : error;
        }
    }
}
