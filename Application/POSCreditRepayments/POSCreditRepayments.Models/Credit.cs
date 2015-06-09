namespace POSCreditRepayments.Models
{
    public class Credit
    {
        public int CreditId { get; set; }

        public decimal Downpayment { get; set; }

        public virtual FinancialInstitution FinancialInstitution { get; set; }

        public string FinancialInstitutionId { get; set; }

        public virtual Insurance Insurance { get; set; }

        public virtual int InsuranceId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public int Term { get; set; }

        public virtual User User { get; set; }

        public string UserId { get; set; }
    }
}