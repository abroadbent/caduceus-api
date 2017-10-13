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

        public bool IsActive { get; set; }

        public DateTimeOffset Created { get; set; }

		public DateTimeOffset? Modified { get; set; }

        public abstract string SearchContent { get; set; }

        public DomainModel()
        {
            this.IsActive = true;
            this.Created = DateTimeOffset.Now;
            this.ObfuscatedId = Guid.NewGuid();
        }
    }
}
