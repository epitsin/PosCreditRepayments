using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class FinancialInstitution
    {
        public int FinancialInstitutionId { get; set; }

        public string Name { get; set; }

        public double InterestRate { get; set; }

        public FinancialInstitution()
        {
            this.Credits = new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}
