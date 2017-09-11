using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class LoggedWork : TenantModel<int>
    {
        public AppUser.AppUser User { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? ClockIn { get; set; }
        public DateTimeOffset? ClockOut { get; set; }

        public WorkOrder WorkOrder { get; set; }

        public TimeSpan? TimeClocked
        {
            get 
            {
                if(this.ClockIn.HasValue && this.ClockOut.HasValue)
                {
                    return this.ClockOut - this.ClockIn;
                }
                else {
                    return null;
                }
            }
        }

        public double TimeClockedInMinutes
        {
            get 
            {
                return this.TimeClocked.GetValueOrDefault().TotalMinutes;
            }
        }

        public LoggedWork()
        {
        }
    }
}
