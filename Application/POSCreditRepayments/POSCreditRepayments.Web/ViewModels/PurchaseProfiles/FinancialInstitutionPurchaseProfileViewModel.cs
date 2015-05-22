using AutoMapper;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;

namespace POSCreditRepayments.Web.ViewModels.PurchaseProfiles
{
    public class FinancialInstitutionPurchaseProfileViewModel : IMapFrom<FinancialInstitutionPurchaseProfile>, IHaveCustomMappings
    {
        public int MonthsMax { get; set; }

        public int MonthsMin { get; set; }

        public decimal PriceMax { get; set; }

        public decimal PriceMin { get; set; }

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