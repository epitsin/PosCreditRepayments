using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public class POSCreditRepaymentsDbContext : IdentityDbContext<User>, IPOSCreditRepaymentsDbContext
    {
        public POSCreditRepaymentsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Credit> Credits { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public IDbSet<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles { get; set; }

        public IDbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<PurchaseProfile> PurchaseProfiles { get; set; }

        public static POSCreditRepaymentsDbContext Create()
        {
            return new POSCreditRepaymentsDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}