using System.Data.Entity;
using System.Linq;

namespace POSCreditRepayments.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(IPOSCreditRepaymentsDbContext context)
        {
            this.Context = context;
            this.Set = context.Set<T>();
        }

        protected IPOSCreditRepaymentsDbContext Context { get; set; }

        protected IDbSet<T> Set { get; set; }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.Set;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public int SaveChanges()
        {
            return this.SaveChanges();
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            entry.State = state;
        }
    }
}