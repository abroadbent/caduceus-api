using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;
using Microsoft.AspNetCore.Identity;

namespace Api.Models.Domain.AppUser
{
    public class AppUser : IdentityUser<int>
    {
        [Required]
        public DateTimeOffset Created { get; set; }

        [MaxLength(25), MinLength(1), Required]
        public string FirstName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(25), MinLength(1), Required]
        public string LastName { get; set; }

        public DateTimeOffset? Modified { get; set; }

        [Required, MaxLength(10)]
        public string Role { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int TenantId { get; set; }

        [MaxLength(255), Required]
        public string SearchContent
        {
            get {
                return string.Join("|", new[] { this.FirstName, this.LastName, this.UserName });
            }
        }

        public virtual Tenant.Tenant Tenant { get; set; }

        public AppUser() 
        {
            this.Created = DateTimeOffset.Now;
            this.IsActive = true;
            this.Role = "user";
        }

        public AppUser(int tenantId, string username) : base(username)
        {
            this.Created = DateTimeOffset.Now;
            this.IsActive = true;
            this.TenantId = tenantId;
            this.Role = "user";
        }

        public AppUser(int tenantId, string username, string firstName, string lastName, string role) : this(tenantId, username) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
        }
    }
}
