namespace POSCreditRepayments.Models
{
    public class Credit
    {
        public int CreditId { get; set; }

        public decimal Downpayment { get; set; }

        public virtual FinancialInstitution FinancialInstitution { get; set; }

        public int FinancialInstitutionId { get; set; }

        public InsuranceType InsuranceType { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public int Term { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}