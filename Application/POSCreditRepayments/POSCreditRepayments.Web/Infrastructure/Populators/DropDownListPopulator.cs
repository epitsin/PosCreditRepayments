using POSCreditRepayments.Data;
using POSCreditRepayments.Web.Infrastructure.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IPOSCreditRepaymentsData data;
        private ICacheService cache;

        public DropDownListPopulator(IPOSCreditRepaymentsData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetFinancialInstitutions()
        {
            var institutions = this.cache.Get<IEnumerable<SelectListItem>>("FinancialInstitutions",
                () =>
                {
                    return this.data.FinancialInstitutions
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.FinancialInstitutionId.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return institutions;
        }
    }
}