using System.ComponentModel.DataAnnotations;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;
using System.Web.Mvc;
using System.Collections.Generic;
using POSCreditRepayments.Web.ViewModels.PurchaseProfiles;
using AutoMapper;

namespace POSCreditRepayments.Web.ViewModels.FinancialInstitutions
{
    public class EditFinancialInstitutionProfileViewModel : IMapFrom<FinancialInstitution>, IHaveCustomMappings
    {
        public string Address { get; set; }

        [Display(Name = "Credit intermediary")]
        public string CreditIntermerdiary { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        
        public decimal MonthlyTax { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Website")]
        public string WebSite { get; set; }

        public List<FinancialInstitutionPurchaseProfileViewModel> FinancialInstitutionPurchaseProfileViewModels { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<FinancialInstitution, EditFinancialInstitutionProfileViewModel>()
                .ForMember(dest => dest.FinancialInstitutionPurchaseProfileViewModels, opt => opt.MapFrom(src => src.FinancialInstitutionPurchaseProfiles));
        }
    }
}