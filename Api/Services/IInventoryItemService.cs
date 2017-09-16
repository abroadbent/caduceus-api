using System;
using System.Threading.Tasks;
using Api.Models.Domain.Inventory;

namespace Api.Services
{
    public interface IInventoryItemService : ICrudService<InventoryItem, CreateInventoryItemViewModel, EditableInventoryItemViewModel, InventoryItemFilter>
    {
        Task<InventoryItemStatus> AdvanceWorkflow(int id);
    }
}
