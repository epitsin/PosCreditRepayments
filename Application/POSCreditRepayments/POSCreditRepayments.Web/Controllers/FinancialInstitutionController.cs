using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using POSCreditRepayments.Data;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.ViewModels.FinancialInstitutions;

namespace POSCreditRepayments.Web.Controllers
{
    [Authorize(Roles = "Financial institution, Admin")]
    public class FinancialInstitutionController : BaseController
    {
        public FinancialInstitutionController(IPOSCreditRepaymentsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult EditFinancialInstitutionProfile(string id)
        {
            EditFinancialInstitutionProfileViewModel institution = this.Data.FinancialInstitutions
                                                                       .All()
                                                                       .Project()
                                                                       .To<EditFinancialInstitutionProfileViewModel>()
                                                                       .FirstOrDefault(x => x.Id == id);

            if (institution != null)
            {
                return this.View(institution);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFinancialInstitutionProfile(EditFinancialInstitutionProfileViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(model.Id);

                if (institution != null)
                {
                    institution.InterestRate = model.InterestRate;
                    institution.Address = model.Address;
                    institution.CreditIntermerdiary = model.CreditIntermerdiary;
                    institution.Email = model.Email;
                    institution.Fax = model.Fax;
                    institution.PhoneNumber = model.PhoneNumber;
                    institution.WebSite = model.WebSite;

                    this.Data.SaveChanges();

                    return this.RedirectToAction("FinancialInstitutionProfile", "FinancialInstitution", model.Id);
                }
            }

            return this.RedirectToAction("Index", "Home"); // TODO: dispaly error
        }

        [HttpGet]
        public ActionResult FinancialInstitutionProfile(string id)
        {
            if(id== null)
            {
                id = this.CurrentUser.Id;
            }

            FinancialInstitutionProfileViewModel institution = this.Data.FinancialInstitutions
                                                                   .All()
                                                                   .Project()
                                                                   .To<FinancialInstitutionProfileViewModel>()
                                                                   .FirstOrDefault(x => x.Id == id);

            if (institution != null)
            {
                return this.View(institution);
            }

            return this.RedirectToAction("Index", "Home"); // TODO: dispaly error
        }
    }
}