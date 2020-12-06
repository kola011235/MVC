using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CorrectAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                var user = (UserModel)validationContext.ObjectInstance;
                if ((DateTime.Now - user.DateIfBirth).Days / 365 != user.Age)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}