using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentDemoModels.Util
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class PastDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.GetType() == typeof(DateTime))
            {
                var dt = Convert.ToDateTime(value);
                var exDate = new DateTime(dt.Year, dt.Month, 1);
                var cDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                if (exDate >= cDate)
                {
                    return ValidationResult.Success;
                }

            }

            return new ValidationResult("Your credit card is expired");
        }
    }

}
