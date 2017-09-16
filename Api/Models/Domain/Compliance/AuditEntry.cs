using System;
using System.Collections.Generic;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Compliance
{
    public class AuditEntry : TenantModel<int>
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AuditEntryChange> Changes { get; set; }

        public AuditEntry()
        {
        }
    }
}
