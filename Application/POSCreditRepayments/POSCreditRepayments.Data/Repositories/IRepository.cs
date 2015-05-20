using System.Linq;

namespace POSCreditRepayments.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IQueryable<T> All();

        void Delete(T entity);

        void Delete(object id);

        T GetById(object id);

        int SaveChanges();

        void Update(T entity);
    }
}