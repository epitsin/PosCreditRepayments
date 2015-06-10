using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using POSCreditRepayments.Data;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Populators;
using POSCreditRepayments.Web.ViewModels.Credits;
using POSCreditRepayments.Web.ViewModels.EuroFormTemplate;
using POSCreditRepayments.Web.ViewModels.FinancialInstitutions;

namespace POSCreditRepayments.Web.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class CreditController : BaseController
    {
        private readonly IDropDownListPopulator populator;

        public CreditController(IPOSCreditRepaymentsData data, IDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }

        public ActionResult Calculate(CreditEditorTemplateViewModel viewModel)
        {
            string institutionId = viewModel.SelectedFinancialInstitutions.FirstOrDefault();
            FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(institutionId);

            Insurance insurance = institution.Insurances.FirstOrDefault(x => x.Type == viewModel.InsuranceType);
            decimal insuranceAmountPerMonth = (decimal)insurance.PercentageRate * viewModel.Product.Price;
            
            decimal creditAmount = viewModel.Product.Price +
                                   institution.ApplicationFee +
                                   insuranceAmountPerMonth * viewModel.Term -
                                   viewModel.Downpayment;

            double interestRate = institution.FinancialInstitutionPurchaseProfiles
                                             .Where(x => x.PurchaseProfile.MonthsMin <= viewModel.Term &&
                                                         x.PurchaseProfile.MonthsMax >= viewModel.Term &&
                                                         x.PurchaseProfile.PriceMin <= creditAmount &&
                                                         x.PurchaseProfile.PriceMax >= creditAmount)
                                             .FirstOrDefault()
                                             .InterestRate;
            double interestRatePerMonth = interestRate / 1200;
            double interestRateForTerm = Math.Pow(1 + interestRatePerMonth, viewModel.Term);

            decimal monthlyPayment = ((decimal)interestRatePerMonth * creditAmount * (decimal)interestRateForTerm) / (decimal)(interestRateForTerm - 1);
            decimal totalAmount = monthlyPayment * viewModel.Term;
            double apr = (Math.Pow(1 + interestRatePerMonth, 12) - 1) * 100;

            this.Data.Credits.Add(new Credit
            {
                Product = viewModel.Product,
                User = this.CurrentUser,
                FinancialInstitution = institution,
                Downpayment = viewModel.Downpayment,
                Insurance = insurance,
                Term = viewModel.Term
            });

            this.Data.SaveChanges();

            CreditDisplayTemplateViewModel model = new CreditDisplayTemplateViewModel
            {
                CreditAmount = Math.Round(creditAmount, 2),
                Downpayment = viewModel.Downpayment,
                FinancialInstitutionName = institution.Name,
                Insurance = viewModel.InsuranceType.ToString(),
                InterestRatePerMonth = Math.Round(interestRate / 12, 2),
                InterestRatePerYear = Math.Round(interestRate, 2),
                TotalAmount = Math.Round(totalAmount, 2),
                InterestAmount = Math.Round(totalAmount - creditAmount, 2),
                Term = viewModel.Term,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                Apr = Math.Round(apr, 2),
                ProductName = viewModel.Product.Name,
                ProductPrice = viewModel.Product.Price,
                InsuranceAmount = insuranceAmountPerMonth
            };

            decimal creditAmountEarlierPayment = viewModel.Product.Price +
                                 institution.ApplicationFee +
                                 insuranceAmountPerMonth * (viewModel.Term - 2) -
                                 viewModel.Downpayment;

            double interestRateEarlierPayment = institution.FinancialInstitutionPurchaseProfiles
                                             .Where(x => x.PurchaseProfile.MonthsMin <= viewModel.Term - 2 &&
                                                         x.PurchaseProfile.MonthsMax >= viewModel.Term - 2 &&
                                                         x.PurchaseProfile.PriceMin <= creditAmountEarlierPayment &&
                                                         x.PurchaseProfile.PriceMax >= creditAmountEarlierPayment)
                                             .FirstOrDefault()
                                             .InterestRate;
            double interestRatePerMonthEarlierPayment = interestRateEarlierPayment / 1200;
            double interestRateForTermEarlierPayment = Math.Pow(1 + interestRatePerMonthEarlierPayment, viewModel.Term - 2);

            decimal monthlyPaymentEarlierPayment = ((decimal)interestRatePerMonthEarlierPayment * creditAmountEarlierPayment * (decimal)interestRateForTermEarlierPayment) / (decimal)(interestRateForTermEarlierPayment - 1);
            decimal totalAmountEarlierPayment = monthlyPaymentEarlierPayment * (viewModel.Term - 2);

            model.EarlierPaymentIncreaseAmount = Math.Round(monthlyPaymentEarlierPayment, 2);
            model.EarlierPaymentIterestSavings = Math.Round((totalAmount - creditAmount) - (totalAmountEarlierPayment - creditAmountEarlierPayment), 2);

            return this.View(model);
        }

        public ActionResult GeneratePdfEuroFormTemplate(CreditDisplayTemplateViewModel model)
        {
            EuroFormTemplateViewModel template = new EuroFormTemplateViewModel();
            template.Credit = model;
            template.FinancialInstitution = this.Data.FinancialInstitutions
                                                .All()
                                                .Where(fi => fi.Name == model.FinancialInstitutionName)
                                                .Project()
                                                .To<EditFinancialInstitutionProfileViewModel>()
                                                .FirstOrDefault();

            return new Rotativa.ViewAsPdf("EuroFormTemplate", template) { FileName = "EuroFormTemlate.pdf" };
        }

        public ActionResult GetOnCredit(int id)
        {
            CreditEditorTemplateViewModel model = new CreditEditorTemplateViewModel();
            model.FinancialInstitutions = this.populator.GetFinancialInstitutions();

            Product product = this.Data.Products.GetById(id);
            model.Product = product;

            return this.View(model);
        }
    }
}