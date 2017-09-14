using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Domain.General
{
    public abstract class DomainModel<T> : IDomainModel<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Required]
        public T Id { get; set; }

        [Required]
        public Guid ObfuscatedId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed), Required]
		public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed), Required]
		public DateTimeOffset Created { get; set; }

		public DateTimeOffset? Modified { get; set; }

        public string SearchContent { get; set; }

        public DomainModel()
        {
            this.IsActive = true;
            this.Created = DateTimeOffset.Now;
        }
    }
}
