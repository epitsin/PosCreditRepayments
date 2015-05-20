using System;
using System.Linq;
using System.Web.Mvc;
using POSCreditRepayments.Data;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Populators;
using POSCreditRepayments.Web.ViewModels.Credits;

namespace POSCreditRepayments.Web.Controllers
{
    public class CreditController : BaseController
    {
        private readonly double highRate = 0.5;

        private readonly double lowRate = 0.01;

        private readonly double maxIteration = 1000;

        private readonly IDropDownListPopulator populator;

        private readonly double precisionRequirement = 0.00000001;

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

            return this.View(model);
        }

        public ActionResult Calculate(CreditViewModel viewModel)
        {
            int institutionId = int.Parse(viewModel.SelectedFinancialInstitutions.FirstOrDefault());
            FinancialInstitution institution = this.Data.FinancialInstitutions.GetById(institutionId);

            double interestRate = (institution.InterestRate / 1200);
            double interestPayment = 1 - 1 / Math.Pow(1 + interestRate, viewModel.Term);
            decimal insurance = viewModel.HasInsurance ? viewModel.Product.Price * 3.3m / 100 : 0;
            double creditAmount = (double)(viewModel.Product.Price - viewModel.Downpayment) + (double)insurance;
            double monthlyPayment = (interestRate * creditAmount) / interestPayment;
            double totalAmount = monthlyPayment * viewModel.Term;

            int numOfFlows = viewModel.Term + 1;
            double[] cashFlows = new double[37];
            cashFlows[0] = -creditAmount;
            for (int i = 1; i <= numOfFlows; i++)
            {
                cashFlows[i] = monthlyPayment + 2;
            }

            double irr = this.ComputeIrr(cashFlows, numOfFlows);

            double apr = Math.Round((Math.Pow(1 + irr, 12) - 1) * 100, 2);

            CalculatedCreditViewModel model = new CalculatedCreditViewModel
            {
                CreditAmount = Math.Round(creditAmount, 2),
                Downpayment = viewModel.Downpayment,
                FinancialInstitutionName = institution.Name,
                Insurance = viewModel.HasInsurance ? "Included" : "Not included",
                InterestRatePerMonth = Math.Round(institution.InterestRate / 12, 2),
                InterestRatePerYear = Math.Round(institution.InterestRate, 2),
                TotalAmount = Math.Round(totalAmount, 2),
                InterestAmount = Math.Round(totalAmount - creditAmount, 2),
                Term = viewModel.Term,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                Irr = Math.Round(irr * 100, 2),
                Apr = apr
            };

            return this.View(model);
        }

        private double ComputeIrr(double[] cf, int numOfFlows)
        {
            double old = 0;
            double newA = 0;
            double newguessRate = this.lowRate;
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
                    npv = npv + (cf[j] / denom);
                }
                
                if ((npv > 0) && (npv < this.precisionRequirement))
                {
                    break;
                }

                if (old == 0)
                {
                    old = npv;
                }
                else
                {
                    old = newA;
                }

                newA = npv;
                if (i > 0)
                {
                    if (old < newA)
                    {
                        if (old < 0 && newA < 0)
                        {
                            highGuessRate = newguessRate;
                        }
                        else
                        {
                            lowGuessRate = newguessRate;
                        }
                    }
                    else
                    {
                        if (old > 0 && newA > 0)
                        {
                            lowGuessRate = newguessRate;
                        }
                        else
                        {
                            highGuessRate = newguessRate;
                        }
                    }
                }

                guessRate = (lowGuessRate + highGuessRate) / 2;
                newguessRate = guessRate;
            }

            return guessRate;
        }
    }
}