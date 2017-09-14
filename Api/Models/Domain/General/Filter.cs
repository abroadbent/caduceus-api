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
        }
    }
}
