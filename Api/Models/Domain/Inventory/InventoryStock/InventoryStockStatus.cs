using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Inventory
{
    public class InventoryStockStatus : Status
    {
		// todo: add real statuses here
		public enum Statuses {
            Normal = 1,
            Damaged = 2
        }

        public InventoryStockStatus()
        {
        }
    }
}
