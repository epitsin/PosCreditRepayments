using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Web.ViewModels.Credits
{
    public class CreditViewModel
    {
        [DisplayName("Down payment")]
        public decimal Downpayment { get; set; }

        [DisplayName("Finanial institution")]
        public IEnumerable<SelectListItem> FinancialInstitutions { get; set; }

        [DisplayName("Product insurance")]
        public bool HasInsurance { get; set; }

        public Product Product { get; set; }

        public IEnumerable<string> SelectedFinancialInstitutions { get; set; }

        [DisplayName("Credit term (months)")]
        [Range(3, 36)]
        public int Term { get; set; }
    }
}