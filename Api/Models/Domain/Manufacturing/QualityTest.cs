using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class QualityTest : TenantModel<int>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string ExpectedResult { get; set; }

        [MaxLength(1000)]
        public string Instructions { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public QualityTest()
        {
        }
    }
}
