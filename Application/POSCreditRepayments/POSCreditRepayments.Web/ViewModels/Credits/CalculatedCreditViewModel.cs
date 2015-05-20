using System.ComponentModel;

namespace POSCreditRepayments.Web.ViewModels.Credits
{
    public class CalculatedCreditViewModel
    {
        [DisplayName("Annual Percentage Rate of Charge (APR)")]
        public double Apr { get; set; }

        [DisplayName("Amount of the credit paid")]
        public double CreditAmount { get; set; }

        [DisplayName("Down payment")]
        public decimal Downpayment { get; set; }

        [DisplayName("Finanial institution")]
        public string FinancialInstitutionName { get; set; }

        [DisplayName("Product insurance")]
        public string Insurance { get; set; }

        [DisplayName("Amount of the interest paid")]
        public double InterestAmount { get; set; }

        [DisplayName("Interest rate (% per month)")]
        public double InterestRatePerMonth { get; set; }

        [DisplayName("Interest rate (% per year)")]
        public double InterestRatePerYear { get; set; }

        [DisplayName("Internal Rate of Return (IRR)")]
        public double Irr { get; set; }

        [DisplayName("Monthly payment")]
        public double MonthlyPayment { get; set; }

        [DisplayName("Credit term (months)")]
        public int Term { get; set; }

        [DisplayName("Total amount to pay (principal + interest)")]
        public double TotalAmount { get; set; }
    }
}