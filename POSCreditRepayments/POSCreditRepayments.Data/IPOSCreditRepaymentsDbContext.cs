using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsDbContext
    {
        //IDbSet<BusinessProcess> BusinessProcesses { get; set; }

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
