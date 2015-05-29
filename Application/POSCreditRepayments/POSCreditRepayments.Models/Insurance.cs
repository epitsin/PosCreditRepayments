using System;
using System.Linq;

namespace POSCreditRepayments.Models
{
    public class Insurance
    {
        public virtual FinancialInstitution FinancialInstitution { get; set; }

        public int FinancialInstitutionId { get; set; }

        public int InsuranceId { get; set; }

        public double PercentageRate { get; set; }

        public InsuranceType Type { get; set; }
    }
}