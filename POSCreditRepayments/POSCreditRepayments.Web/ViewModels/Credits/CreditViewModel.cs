using AutoMapper;
using POSCreditRepayments.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.ViewModels.Credits
{
    public class CreditViewModel
    {
        [DisplayName("Credit term (months)")]
        [Range(3, 36)]
        public int Term { get; set; }

        [DisplayName("Product insurance")]
        public bool HasInsurance { get; set; }

        [DisplayName("Down payment")]
        public decimal Downpayment { get; set; }

        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }

        public IEnumerable<string> SelectedFinancialInstitutions { get; set; }

        public IEnumerable<SelectListItem> FinancialInstitutions { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Credit, CreditViewModel>()
                .ForMember(m => m.TotalAmount, opt => opt.MapFrom(t => t.Product.Price))
                .ReverseMap();          
        }
    }
}