using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Compliance
{
    public class AuditEntryChange : TenantModel<int>
    {
        public string Model { get; set; }
        public string Field { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }

        public AuditEntryChange()
        {
        }
    }
}
