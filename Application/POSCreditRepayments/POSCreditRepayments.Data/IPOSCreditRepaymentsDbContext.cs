using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsDbContext
    {
        IDbSet<Credit> Credits { get; set; }

        DbContext DbContext { get; }

        IDbSet<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles { get; set; }

        IDbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<PurchaseProfile> PurchaseProfiles { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;
    }
}