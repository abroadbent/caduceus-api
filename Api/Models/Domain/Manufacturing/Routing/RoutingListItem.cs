using System;
namespace Api.Models.Domain.Manufacturing
{
    public class RoutingListItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
