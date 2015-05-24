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
        private readonly double highRate = 0.5;

        private readonly double lowRate = 0.01;

        private readonly double maxIteration = 100;

        private readonly IDropDownListPopulator populator;

        private readonly double precisionRequirement = 0.00000001;

        public CreditController(IPOSCreditRepaymentsData data, IDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }

        public ActionResult Calculate(CreditEditorTemplateViewModel viewModel)
        {
            string institutionId = viewModel.SelectedFinancialInstitutions.FirstOrDefault();
            FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(institutionId);
            
            decimal priceWithoutDownpayment = (viewModel.Product.Price - viewModel.Downpayment);
            double interestRate = institution.FinancialInstitutionPurchaseProfiles
                                             .Where(x => x.PurchaseProfile.MonthsMin <= viewModel.Term &&
                                                         x.PurchaseProfile.MonthsMax >= viewModel.Term &&
                                                         x.PurchaseProfile.PriceMin <= priceWithoutDownpayment &&
                                                         x.PurchaseProfile.PriceMax >= priceWithoutDownpayment)
                                             .FirstOrDefault()
                                             .InterestRate;
            double interestRatePerMonthInDouble = interestRate / 1200;

            double interestPayment = 1 - 1 / Math.Pow(1 + interestRatePerMonthInDouble, viewModel.Term);
            decimal insurance = this.CalculateInsurance(viewModel.InsuranceType) * priceWithoutDownpayment;
            decimal creditAmount = priceWithoutDownpayment + insurance;
            decimal monthlyPayment = ((decimal)interestRatePerMonthInDouble * creditAmount) / (decimal)interestPayment;
            decimal totalAmount = monthlyPayment * viewModel.Term;

            int numOfFlows = viewModel.Term + 1;
            decimal[] cashFlows = new decimal[37];
            cashFlows[0] = -creditAmount;
            for (int i = 1; i <= numOfFlows; i++)
            {
                cashFlows[i] = monthlyPayment + institution.MonthlyTax;
            }

            double irr = this.ComputeIrr(cashFlows, numOfFlows);
            double apr = (Math.Pow(1 + irr, 12) - 1) * 100;

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
                MonthlyTax = institution.MonthlyTax,
                Irr = Math.Round(irr * 100, 2),
                Apr = Math.Round(apr, 2),
                ProductName = viewModel.Product.Name,
                ProductPrice = viewModel.Product.Price,
                InsuranceAmount = insurance
            };

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

        private decimal CalculateInsurance(InsuranceType insuranceType)
        {
            switch (insuranceType)
            {
                case InsuranceType.Life:
                    return 0.02m;
                case InsuranceType.Unemployment:
                    return 0.03m;
                case InsuranceType.LifeAndUnemployment:
                    return 0.05m;
                case InsuranceType.Purchase:
                    return 0.04m;
                case InsuranceType.All:
                    return 0.09m;
                default:
                    return 0;
            }
        }

        private double ComputeIrr(decimal[] cf, int numOfFlows)
        {
            double oldNpv = 0;
            double newNpv = 0;
            double newGuessRate = this.lowRate;
            double guessRate = this.lowRate;
            double lowGuessRate = this.lowRate;
            double highGuessRate = this.highRate;
            double npv = 0;
            double denom = 0;
            for (int i = 0; i < this.maxIteration; i++)
            {
                npv = 0;
                for (int j = 0; j < numOfFlows; j++)
                {
                    denom = Math.Pow((1 + guessRate), j);
                    npv = npv + ((double)cf[j] / denom);
                }

                if ((npv > 0) && (npv < this.precisionRequirement))
                {
                    break;
                }

                if (oldNpv == 0)
                {
                    oldNpv = npv;
                }
                else
                {
                    oldNpv = newNpv;
                }

                newNpv = npv;
                if (i > 0)
                {
                    if (oldNpv < newNpv)
                    {
                        if (oldNpv < 0 && newNpv < 0)
                        {
                            highGuessRate = newGuessRate;
                        }
                        else
                        {
                            lowGuessRate = newGuessRate;
                        }
                    }
                    else
                    {
                        if (oldNpv > 0 && newNpv > 0)
                        {
                            lowGuessRate = newGuessRate;
                        }
                        else
                        {
                            highGuessRate = newGuessRate;
                        }
                    }
                }

                guessRate = (lowGuessRate + highGuessRate) / 2;
                newGuessRate = guessRate;
            }

            return guessRate;
        }
    }
}