using AutoMapper;

namespace POSCreditRepayments.Web.Infrastructure.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}