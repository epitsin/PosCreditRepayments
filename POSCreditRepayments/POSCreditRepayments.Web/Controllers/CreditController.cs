using System.Collections.Generic;
using POSCreditRepayments.Data;
using POSCreditRepayments.Web.Infrastructure.Populators;
using POSCreditRepayments.Web.ViewModels.Credits;
using System.Web.Mvc;
using System;
using System.Linq;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Web.Controllers
{
    public class CreditController : BaseController
    {
        private readonly IDropDownListPopulator populator;

        public CreditController(IPOSCreditRepaymentsData data, IDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }

        public ActionResult BuyProduct(int id)
        {
            CreditViewModel model = new CreditViewModel();
            model.FinancialInstitutions = this.populator.GetFinancialInstitutions();

            Product product = this.Data.Products.GetById(id);
            model.Product = product;

            return View(model);
        }

        public ActionResult Calculate(CreditViewModel viewModel)
        {
            int institutionId = int.Parse(viewModel.SelectedFinancialInstitutions.FirstOrDefault());
            FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(institutionId);

            double interestRate = (institution.MonthsOneToThree / 1200);
            double interestPayment = 1 - 1 / Math.Pow(1 + interestRate, viewModel.Term);
            decimal insurance = viewModel.HasInsurance ? viewModel.Product.Price * 3.3m / 100 : 0;
            double totalPriceToPay = (double)(viewModel.Product.Price - viewModel.Downpayment) + (double)insurance;
            double monthlyPayment = (interestRate * totalPriceToPay) / interestPayment;

            double monthlyPaymentRounded = Math.Round(monthlyPayment, 2);

            return View(monthlyPaymentRounded);
        }
    }
}