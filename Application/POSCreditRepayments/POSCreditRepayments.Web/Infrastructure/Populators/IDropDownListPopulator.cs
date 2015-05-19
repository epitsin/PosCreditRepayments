using System.Collections.Generic;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.Infrastructure.Populators
{
    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetFinancialInstitutions();
    }
}