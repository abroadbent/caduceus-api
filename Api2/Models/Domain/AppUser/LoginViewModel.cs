using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class LoginViewModel : IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(this.Username))
            {
                yield return new ValidationResult("Username is required.");
            }

            if(string.IsNullOrWhiteSpace(this.Password))
            {
                yield return new ValidationResult("Password is required.");
            }
        }
    }
}
