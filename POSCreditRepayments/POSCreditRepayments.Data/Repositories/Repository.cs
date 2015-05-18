using System.Data.Entity;
using System.Linq;

namespace POSCreditRepayments.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IPOSCreditRepaymentsDbContext context;

        private IDbSet<T> set;

        public Repository(IPOSCreditRepaymentsDbContext context)
        {
            this.Context = context;
            this.Set = context.Set<T>();
        }

        protected IPOSCreditRepaymentsDbContext Context
        {
            get { return this.context; }
            set { this.context = value; }
        }

        protected IDbSet<T> Set
        {
            get { return this.set; }
            set { this.set = value; }
        }

        public IQueryable<T> All()
        {
            return this.Set;
        }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
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

        public int SaveChanges()
        {
            return this.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            entry.State = state;
        }
    }
}
