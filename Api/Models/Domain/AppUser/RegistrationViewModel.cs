using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class RegistrationViewModel : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }

        public string Email
        {
            get
            {
                return this.Username;
            }
        }

        public RegistrationViewModel()
        {
        }

        public RegistrationViewModel(string firstName, string lastName, string username, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                yield return new ValidationResult("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(this.LastName))
            {
                yield return new ValidationResult("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(this.Username))
            {
                yield return new ValidationResult("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(this.Password))
            {
                yield return new ValidationResult("Password is required.");
            }
        }
    }
}
