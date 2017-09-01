using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.General
{
    public class DomainModel : IDomainModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Guid ObfuscatedId { get; set; }

        [Required]
		public bool IsActive { get; set; }

        [Required]
		public DateTimeOffset Created { get; set; }

		public DateTimeOffset? Modified { get; set; }

        public DomainModel()
        {
            this.IsActive = true;
            this.Created = DateTimeOffset.Now;
        }
    }
}
