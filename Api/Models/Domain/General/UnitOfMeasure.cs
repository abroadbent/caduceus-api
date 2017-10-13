using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.General
{
    public class UnitOfMeasure : TenantModel<int>
    {
        [MaxLength(10), Required]
        public string Code { get; set; }

        public string Description { get; set; }

        [MaxLength(25), Required]
        public string Name { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Code, this.Name, this.Description });
            }
            set { value = ""; }
        }

        public UnitOfMeasure()
        {
        }
    }
}
