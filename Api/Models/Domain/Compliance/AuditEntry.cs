using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Compliance
{
    public class AuditEntry : TenantModel<int>
    {
        [MaxLength(25), MinLength(1)]
        public string FirstName { get; set; }

		[MaxLength(25), MinLength(1)]
		public string LastName { get; set; }

        [MaxLength(1000), MinLength(1), Required]
        public string Message { get; set; }

        [EmailAddress, Required]
        public string Username { get; set; }

        public override string SearchContent {
            get
            {
                return string.Join("|", new[] { this.FirstName, this.LastName, this.Username, this.Message });
            }
            set { value = ""; }
        }

        public virtual ICollection<AuditEntryChange> Changes { get; set; }

        public AuditEntry()
        {
        }
    }
}
