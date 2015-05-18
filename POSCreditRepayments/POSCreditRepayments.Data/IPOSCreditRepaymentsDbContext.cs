using POSCreditRepayments.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsDbContext
    {
        IDbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        IDbSet<Product> Products { get; set; }

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
