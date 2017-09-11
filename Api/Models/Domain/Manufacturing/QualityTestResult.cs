using System;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.Manufacturing
{
    public class QualityTestResult : TenantModel<int>
    {
        public QualityTest Test { get; set; }
        public bool IsPassed { get; set; }
        public object Result { get; set; }
        public string Notes { get; set; }

		public QualityTestResult()
        {
        }
    }
}
