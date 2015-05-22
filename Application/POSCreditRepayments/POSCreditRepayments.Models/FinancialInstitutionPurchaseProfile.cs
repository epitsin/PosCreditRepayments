namespace POSCreditRepayments.Models
{
    public class FinancialInstitutionPurchaseProfile
    {
        public virtual FinancialInstitution FinancialInstitution { get; set; }

        public string FinancialInstitutionId { get; set; }

        public int FinancialInstitutionPurchaseProfileId { get; set; }

        public double InterestRate { get; set; }

        public virtual PurchaseProfile PurchaseProfile { get; set; }

        public int PurchaseProfileId { get; set; }
    }
}