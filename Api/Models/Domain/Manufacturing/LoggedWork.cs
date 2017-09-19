using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class LoggedWork : TenantModel<int>
    {
		public DateTimeOffset? ClockIn { get; set; }
		public DateTimeOffset? ClockOut { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? WorkOrderId { get; set; }

        public virtual AppUser.AppUser User { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

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
