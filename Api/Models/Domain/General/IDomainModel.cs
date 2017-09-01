using System;
namespace Api.Models.Domain.General
{
    public interface IDomainModel
    {
        int Id { get; set; }
        bool IsActive { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset? Modified { get; set; }
        Guid ObfuscatedId { get; set; }
    }
}
