using AutoMapper;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;
using System.ComponentModel.DataAnnotations;

namespace POSCreditRepayments.Web.ViewModels.PurchaseProfiles
{
    public class FinancialInstitutionPurchaseProfileViewModel : IMapFrom<FinancialInstitutionPurchaseProfile>, IHaveCustomMappings
    {
        [Range(3, 36)]
        [Required]
        public int MonthsMax { get; set; }

        [Range(3, 36)]
        [Required]
        public int MonthsMin { get; set; }

        [Range(50, 100000)]
        [Required]
        public decimal PriceMax { get; set; }

        [Range(50, 100000)]
        [Required]
        public decimal PriceMin { get; set; }

        [Range(0.1, 50)]
        [Required]
        public double InterestRate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<FinancialInstitutionPurchaseProfile, FinancialInstitutionPurchaseProfileViewModel>()
                .ForMember(dest => dest.MonthsMin, opt => opt.MapFrom(src => src.PurchaseProfile.MonthsMin));
            Mapper.CreateMap<FinancialInstitutionPurchaseProfile, FinancialInstitutionPurchaseProfileViewModel>()
                .ForMember(dest => dest.MonthsMax, opt => opt.MapFrom(src => src.PurchaseProfile.MonthsMax));
            Mapper.CreateMap<FinancialInstitutionPurchaseProfile, FinancialInstitutionPurchaseProfileViewModel>()
                .ForMember(dest => dest.PriceMin, opt => opt.MapFrom(src => src.PurchaseProfile.PriceMin));
            Mapper.CreateMap<FinancialInstitutionPurchaseProfile, FinancialInstitutionPurchaseProfileViewModel>()
                .ForMember(dest => dest.PriceMax, opt => opt.MapFrom(src => src.PurchaseProfile.PriceMax));
        }
    }
}