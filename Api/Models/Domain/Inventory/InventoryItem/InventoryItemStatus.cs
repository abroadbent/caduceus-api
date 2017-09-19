using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Inventory
{
    public class InventoryItemStatus : Status
    {
        // todo: add real statuses here
        public enum Statuses
        {
            Unknown = 1    
        }

        public InventoryItemStatus()
        {
        }
    }
}
