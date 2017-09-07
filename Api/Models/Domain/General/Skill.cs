using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.General
{
    public class Skill : TenantModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Skill()
        {
        }
    }
}
