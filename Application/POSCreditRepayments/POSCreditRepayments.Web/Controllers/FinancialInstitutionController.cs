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
                    institution.Address = model.Address;
                    institution.CreditIntermerdiary = model.CreditIntermerdiary;
                    institution.Email = model.Email;
                    institution.Fax = model.Fax;
                    institution.PhoneNumber = model.PhoneNumber;
                    institution.WebSite = model.WebSite;
                    institution.ApplicationFee = model.ApplicationFee;
                    institution.MonthlyFee = model.MonthlyFee;

                    foreach (var viewModel in model.FinancialInstitutionPurchaseProfileViewModels)
                    {
                        FinancialInstitutionPurchaseProfile financialInstitutionPurchaseProfile =
                            this.Data.FinancialInstitutionPurchaseProfiles
                            .All()
                            .FirstOrDefault(p => p.PurchaseProfile.MonthsMin == viewModel.MonthsMin &&
                                                 p.PurchaseProfile.MonthsMax == viewModel.MonthsMax &&
                                                 p.PurchaseProfile.PriceMin == viewModel.PriceMin &&
                                                 p.PurchaseProfile.PriceMax == viewModel.PriceMax &&
                                                 p.FinancialInstitutionId == institution.Id);

                        if (financialInstitutionPurchaseProfile == null)
                        {
                            PurchaseProfile purchaseProfile = this.Data.PurchaseProfiles
                                                                  .All()
                                                                  .FirstOrDefault(p => p.MonthsMin == viewModel.MonthsMin &&
                                                                                       p.MonthsMax == viewModel.MonthsMax &&
                                                                                       p.PriceMin == viewModel.PriceMin &&
                                                                                       p.PriceMax == viewModel.PriceMax);

                            if (purchaseProfile == null)
                            {
                                purchaseProfile = new PurchaseProfile
                                {
                                    MonthsMin = viewModel.MonthsMin,
                                    MonthsMax = viewModel.MonthsMax,
                                    PriceMin = viewModel.PriceMin,
                                    PriceMax = viewModel.PriceMax
                                };

                                this.Data.PurchaseProfiles.Add(purchaseProfile);
                            }

                            financialInstitutionPurchaseProfile = new FinancialInstitutionPurchaseProfile
                            {
                                PurchaseProfile = purchaseProfile,
                                FinancialInstitution = institution
                            };

                            this.Data.FinancialInstitutionPurchaseProfiles.Add(financialInstitutionPurchaseProfile);
                        }

                        financialInstitutionPurchaseProfile.InterestRate = viewModel.InterestRate;
                    }

                    this.Data.SaveChanges();

                    return this.RedirectToAction("FinancialInstitutionProfile", "FinancialInstitution", model.Id);
                }
            }

            return this.RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public ActionResult FinancialInstitutionProfile(string id)
        {
            if (id == null)
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

            return this.RedirectToAction("Error", "Home");
        }
    }
}