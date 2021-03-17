using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace PaymentDemoModels.Util
{

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class SecurityCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value != null && value.GetType() == typeof(string))
            {
                string sc = Convert.ToString(value);
                if (string.IsNullOrEmpty(sc))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    if (sc.Length == 3 && Regex.IsMatch(sc, @"\d{3}"))
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult("Invalid security code");
        }
    }
}
