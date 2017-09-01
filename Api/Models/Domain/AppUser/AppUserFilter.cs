using System;
using Api.Models.Domain.General;

namespace Api.Models.Domain.AppUser
{
    public class AppUserFilter : Filter
    {
        public string SearchCriteria { get; set; }

        public AppUserFilter()
        {
        }
    }
}
