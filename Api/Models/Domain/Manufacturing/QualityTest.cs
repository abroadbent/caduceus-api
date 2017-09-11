using System;
using System.Collections.Generic;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class QualityTest : TenantModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public object ExpectedResult { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        public QualityTest()
        {
        }
    }
}
