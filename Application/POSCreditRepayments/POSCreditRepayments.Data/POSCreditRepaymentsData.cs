using System;
using System.Collections.Generic;
using POSCreditRepayments.Data.Repositories;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public class POSCreditRepaymentsData : IPOSCreditRepaymentsData
    {
        private readonly IPOSCreditRepaymentsDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public POSCreditRepaymentsData(IPOSCreditRepaymentsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Credit> Credits
        {
            get
            {
                return this.GetRepository<Credit>();
            }
        }

        public IRepository<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles
        {
            get
            {
                return this.GetRepository<FinancialInstitutionPurchaseProfile>();
            }
        }

        public IRepository<FinancialInstitution> FinancialInstitutions
        {
            get
            {
                return this.GetRepository<FinancialInstitution>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<PurchaseProfile> PurchaseProfiles
        {
            get
            {
                return this.GetRepository<PurchaseProfile>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

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