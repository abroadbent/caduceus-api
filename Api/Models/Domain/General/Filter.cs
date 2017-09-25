using System;
namespace Api.Models.Domain.General
{
    public class Filter : IFilter
    {
        public bool? IsActive { get; set; }
        public DateTimeOffsetRange Created { get; set; }
		public DateTimeOffsetRange Modified { get; set; }
		public string SearchCriteria { get; set; }

        public Filter()
        {
            // by default let's return only active records, however, if intentionally
            // set to null then we can return all records.  If intentionally set to
            // false, we will return only inactive records.
            this.IsActive = true;
        }
    }
}
