using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class PurchaseProfile
    {
        public PurchaseProfile()
        {
            this.FinancialInstitutionPurchaseProfiles = new HashSet<FinancialInstitutionPurchaseProfile>();
        }

        public virtual ICollection<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles { get; set; }

        public int PurchaseProfileId { get; set; }

        public int MonthsMax { get; set; }

        public int MonthsMin { get; set; }

        public decimal PriceMax { get; set; }

        public decimal PriceMin { get; set; }
    }
}