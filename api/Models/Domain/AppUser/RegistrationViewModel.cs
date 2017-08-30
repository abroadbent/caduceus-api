using System;
namespace Api.Models.Domain.AppUser
{
    public class RegistrationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public RegistrationViewModel(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
