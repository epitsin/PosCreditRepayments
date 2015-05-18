using POSCreditRepayments.Data.Repositories;
using POSCreditRepayments.Models;
using System;
using System.Collections.Generic;

namespace POSCreditRepayments.Data
{
    public class POSCreditRepaymentsData : IPOSCreditRepaymentsData
    {
        private IPOSCreditRepaymentsDbContext context;

        private IDictionary<Type, object> repositories;

        public POSCreditRepaymentsData(IPOSCreditRepaymentsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        //public IRepository<ITSystem> ITSystems
        //{
        //    get
        //    {
        //        return this.GetRepository<ITSystem>();
        //    }
        //}

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepisitory = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepisitory))
            {
                var repositoryType = typeof(Repository<T>);

                var newRepository = Activator.CreateInstance(repositoryType, this.context);

                this.repositories.Add(typeOfRepisitory, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepisitory];
        }
    }
}
