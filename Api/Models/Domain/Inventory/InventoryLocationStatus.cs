using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Inventory
{
    public class InventoryLocationStatus : Status
    {
        // todo: add real statuses here
        public enum Statuses
        {
            Normal = 1,
            Damaged = 2,
            Quarantine = 3
        }

        public InventoryLocationStatus()
        {
        }
    }
}
