using Gymbokning.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Validations
{
    public class StartTimeCheckAttribute : ValidationAttribute, IClientModelValidator
    {
        public StartTimeCheckAttribute()
        {
            ErrorMessage = "Date cannot be earlier than today!";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var model = (GymClass)validationContext.ObjectInstance;
            if (model.StartTime < DateTime.Now)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-timecheck", ErrorMessage);
        }
    }
}