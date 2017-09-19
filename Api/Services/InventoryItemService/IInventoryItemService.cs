using System;
using System.Threading.Tasks;
using Api.Models.Domain.Inventory;

namespace Api.Services
{
    public interface IInventoryItemService : ICrudService<InventoryItem, InventoryItem, InventoryItem, InventoryItemFilter>
    {
        Task<InventoryItemStatus> AdvanceWorkflow(int id);
    }
}
