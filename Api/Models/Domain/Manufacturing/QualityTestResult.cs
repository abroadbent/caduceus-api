using System;
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

        public virtual QualityTest QualityTest { get; set; }

		public QualityTestResult()
        {
        }
    }
}
