using System;
using Api.Models.Domain.Inventory;

namespace Api.Services
{
    public interface IInventoryItemService : ICrudService<InventoryItem, CreateInventoryItemViewModel, EditableInventoryItemViewModel, InventoryItemFilter>
    {
    }
}
