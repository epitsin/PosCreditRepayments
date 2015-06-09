using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using POSCreditRepayments.Data;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.ViewModels.FinancialInstitutions;

namespace POSCreditRepayments.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(IPOSCreditRepaymentsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult AllFinancialInstitutions()
        {
            IList<AllFinancialInstitutionsViewModel> institutions = this.GetFinancialInstitutions();
            return this.View("AllFinancialInstitutions", institutions);
        }

        [HttpPost]
        public ActionResult ToggleFinancialInstitutionsStatus(string id)
        {
            FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(id);

            if (institution != null)
            {
                institution.IsApproved = institution.IsApproved == true ? false : true;
                this.Data.SaveChanges();
            }

            IList<AllFinancialInstitutionsViewModel> institutions = this.GetFinancialInstitutions();

            return this.PartialView("_AllFinancialInstitutionsPartial", institutions);
        }

        [NonAction]
        private IList<AllFinancialInstitutionsViewModel> GetFinancialInstitutions()
        {
            IList<AllFinancialInstitutionsViewModel> institutions = this.Data.FinancialInstitutions
                                                                        .All().Project()
                                                                        .To<AllFinancialInstitutionsViewModel>()
                                                                        .OrderBy(cp => cp.UserName)
                                                                        .ToList();

            return institutions;
        }
    }
}