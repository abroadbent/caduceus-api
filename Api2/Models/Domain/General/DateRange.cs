using System;
namespace Api.Models.Domain.General
{
    public struct DateTimeOffsetRange
    {
        public DateTimeOffset? End { get; set; }
        public DateTimeOffset? Start { get; set; }

        public bool HasValue 
        {
            get {
                return this.End.HasValue || this.Start.HasValue;
            }   
        }
    }
}
