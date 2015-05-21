using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class FinancialInstitution : User
    {
        public FinancialInstitution()
        {
            this.Credits = new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits { get; set; }

        public double InterestRate { get; set; }

        public double MonthlyTax { get; set; }

        public bool IsApproved { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }

        public string WebSite { get; set; }

        public string CreditIntermerdiary { get; set; }
    }
}