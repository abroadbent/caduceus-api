using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.General
{
    public abstract class Status : DomainModel<int>
    {
        [MinLength(1), MaxLength(10), Required]
        public string Code { get; set; }

        public string Description { get; set; }

        [MinLength(1), MaxLength(25), Required]
        public string Name { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Code, this.Name, this.Description });
            }
            set { value = ""; }
        }

        public Status()
        {
        }
    }
}
