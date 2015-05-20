using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsDbContext
    {
        DbContext DbContext { get; }

        IDbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        IDbSet<Product> Products { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;
    }
}
