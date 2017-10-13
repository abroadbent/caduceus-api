using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Compliance
{
    public class AuditEntryChange : TenantModel<int>
    {
        [MaxLength(100), Required]
        public string Field { get; set; }

        [MaxLength(100), Required]
        public string Model { get; set; }

        [Required]
        public string PreviousValue { get; set; }

        [Required]
        public string NewValue { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Field, this.Model });
            }
            set { value = ""; }
        }

        public AuditEntryChange()
        {
        }
    }
}
