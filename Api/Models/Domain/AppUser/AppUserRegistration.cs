using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class AppUserRegistration
    {
		[MaxLength(25), MinLength(1), Required]
		public string FirstName { get; set; }

		[MaxLength(25), MinLength(1), Required]
		public string LastName { get; set; }

        [MinLength(6), MaxLength(25), Required]
        public string Password { get; set; }

        [MinLength(6), MaxLength(25), Required]
        public string ConfirmPassword { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public int TenantId { get; set; }

        [EmailAddress]
        public string Username { get; set; }

        public string Email
        {
            get
            {
                return this.Username;
            }
        }

        public AppUserRegistration()
        {
        }

        public AppUserRegistration(int tenantId, string firstName, string lastName, string username, string password)
        {
            this.TenantId = tenantId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
        }
    }
}
