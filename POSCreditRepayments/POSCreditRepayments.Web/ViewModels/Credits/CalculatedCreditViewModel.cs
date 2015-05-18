using System.ComponentModel;

namespace POSCreditRepayments.Web.ViewModels.Credits
{
    public class CalculatedCreditViewModel
    {
        [DisplayName("Credit term (months)")]
        public int Term { get; set; }

        [DisplayName("Product insurance")]
        public string Insurance { get; set; }

        [DisplayName("Down payment")]
        public decimal Downpayment { get; set; }

        [DisplayName("Total amount")]
        public double TotalAmount { get; set; }

        [DisplayName("Interest rate")]
        public double InterestRate { get; set; }

        [DisplayName("Monthly payment")]
        public double MonthlyPayment { get; set; }

        [DisplayName("Finanial institution")]
        public string FinancialInstitutionName { get; set; }
    }
}