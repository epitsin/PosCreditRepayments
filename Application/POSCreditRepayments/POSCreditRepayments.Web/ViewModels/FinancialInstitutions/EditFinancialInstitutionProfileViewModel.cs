using System.ComponentModel.DataAnnotations;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.ViewModels.FinancialInstitutions
{
    public class EditFinancialInstitutionProfileViewModel : IMapFrom<FinancialInstitution>
    {
        public string Address { get; set; }

        [Display(Name = "Credit intermediary")]
        public string CreditIntermerdiary { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "Interest rate")]
        public double InterestRate { get; set; }

        public double MonthlyTax { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Website")]
        public string WebSite { get; set; }
    }
}