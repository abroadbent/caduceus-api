using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Api.Models.Domain.AppUser
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public AppUser(string firstName, string lastName, string username) : base(username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
