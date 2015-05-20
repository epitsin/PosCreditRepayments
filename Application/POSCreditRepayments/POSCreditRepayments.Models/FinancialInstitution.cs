using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class FinancialInstitution
    {
        public FinancialInstitution()
        {
            this.Credits = new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits { get; set; }

        public int FinancialInstitutionId { get; set; }

        public double InterestRate { get; set; }

        public string Name { get; set; }
    }
}