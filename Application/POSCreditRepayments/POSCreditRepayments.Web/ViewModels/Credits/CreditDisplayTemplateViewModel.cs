using System.ComponentModel;

namespace POSCreditRepayments.Web.ViewModels.Credits
{
    public class CreditDisplayTemplateViewModel
    {
        [DisplayName("Annual Percentage Rate of Charge (APR in %)")]
        public double Apr { get; set; }

        [DisplayName("Amount of the credit paid")]
        public decimal CreditAmount { get; set; }

        [DisplayName("Down payment")]
        public decimal Downpayment { get; set; }

        public decimal EarlierPaymentIncreaseAmount { get; set; }

        public decimal EarlierPaymentIterestSavings { get; set; }

        [DisplayName("Finanial institution")]
        public string FinancialInstitutionName { get; set; }

        [DisplayName("Product insurance")]
        public string Insurance { get; set; }

        [DisplayName("Insurance amount")]
        public decimal InsuranceAmount { get; set; }

        [DisplayName("Amount of the interest paid")]
        public decimal InterestAmount { get; set; }

        [DisplayName("Interest rate (% per month)")]
        public double InterestRatePerMonth { get; set; }

        [DisplayName("Interest rate (% per year)")]
        public double InterestRatePerYear { get; set; }

        [DisplayName("Monthly payment")]
        public decimal MonthlyPayment { get; set; }

        [DisplayName("Product name")]
        public string ProductName { get; set; }

        [DisplayName("Product price")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Credit term (months)")]
        public int Term { get; set; }

        [DisplayName("Total amount to pay (principal + interest)")]
        public decimal TotalAmount { get; set; }
    }
}