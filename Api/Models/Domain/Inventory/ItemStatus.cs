using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.Inventory
{
    public class ItemStatus : Status
	{
		// todo: add real statuses here
		public enum Statuses
		{
			Normal = 1,
			Damaged = 2,
			Quarantined = 3
		}

        public ItemStatus(Statuses status)
        {
            this.Id = (int)status;
        }
    }
}
