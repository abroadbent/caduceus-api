using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Username { get; set; }

		[MinLength(6), MaxLength(25), Required]
		public string Password { get; set; }

        public LoginViewModel()
        {
        }

        public LoginViewModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
