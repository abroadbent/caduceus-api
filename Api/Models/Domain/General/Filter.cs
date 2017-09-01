using System;
namespace Api.Models.Domain.General
{
    public class Filter
    {
        public bool? IsActive { get; set; }
        public DateTimeOffsetRange Created { get; set; }
        public DateTimeOffsetRange Modified { get; set; }

        public Filter()
        {
        }
    }
}
