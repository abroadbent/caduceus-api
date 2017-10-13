using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.General;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class QualityTestResult : DomainModel<int>
    {
        public bool IsPassed { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Range(1, int.MaxValue), Required]
        public int QualityTestId { get; set; }

        public string Result { get; set; }

        public override string SearchContent
        {
            get
            {
                return string.Join("|", new[] { this.Notes, this.Result });
            }
            set { value = ""; }
        }

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual QualityTest QualityTest { get; set; }

		public QualityTestResult()
        {
        }
    }
}
