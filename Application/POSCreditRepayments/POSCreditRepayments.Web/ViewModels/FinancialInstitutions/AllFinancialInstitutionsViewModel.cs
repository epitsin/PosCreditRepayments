using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;
using System;
using System.Linq;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.ViewModels.FinancialInstitutions
{
    public class AllFinancialInstitutionsViewModel : IMapFrom<FinancialInstitution>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public bool IsApproved { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }
    }
}