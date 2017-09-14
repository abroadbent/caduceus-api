using System;
using System.Linq;
using Api.Models.Domain.General;

namespace Api.Services
{
    public static class QueryableFilterExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, Filter filter) where T : DomainModel<int>
        {
			if (filter.Created.HasValue)
			{
				query.Where(a => a.Created >= filter.Created.Start && a.Created <= filter.Created.End);
			}

			if (filter.IsActive.HasValue)
			{
				query.Where(a => a.IsActive == filter.IsActive);
			}

			if (filter.Modified.HasValue)
			{
				query.Where(a => a.Modified >= filter.Modified.Start && a.Modified <= filter.Modified.End);
			}

			if (!string.IsNullOrWhiteSpace(filter.SearchCriteria))
			{
				query.Where(a => a.SearchContent.Contains(filter.SearchCriteria));
			}

            return query;
        }
    }
}
