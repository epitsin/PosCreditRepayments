using POSCreditRepayments.Web.ViewModels.Credits;
using POSCreditRepayments.Web.ViewModels.FinancialInstitutions;

namespace POSCreditRepayments.Web.ViewModels.EuroFormTemplate
{
    public class EuroFormTemplateViewModel
    {
        public CreditDisplayTemplateViewModel Credit { get; set; }

        public EditFinancialInstitutionProfileViewModel FinancialInstitution { get; set; }
    }
}