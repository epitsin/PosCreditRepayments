using POSCreditRepayments.Data.Repositories;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsData
    {
        IRepository<Credit> Credits { get; }

        IRepository<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles { get; }

        IRepository<FinancialInstitution> FinancialInstitutions { get; }

        IRepository<Product> Products { get; }

        IRepository<PurchaseProfile> PurchaseProfiles { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}