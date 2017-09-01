using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Api.Models.Domain.General;
using Microsoft.AspNetCore.Identity;

namespace Api.Models.Domain.AppUser
{
    public class AppUser : IdentityUser
    {
        [Required]
        public DateTimeOffset Created { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTimeOffset? Modified { get; set; }

        [Required]
        public string SearchContent
        {
            get {
                return string.Join("|", new[] { this.FirstName, this.LastName, this.UserName });
            }
        }

        public AppUser() 
        {
        }

        public AppUser(string username) : base(username)
        {   
        }

        public AppUser(string firstName, string lastName, string username) : this(username) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
