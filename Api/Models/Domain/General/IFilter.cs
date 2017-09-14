using System;
namespace Api.Models.Domain.General
{
    public interface IFilter
    {
		bool? IsActive { get; set; }
		DateTimeOffsetRange Created { get; set; }
		DateTimeOffsetRange Modified { get; set; }
		string SearchCriteria { get; set; }
    }
}
