using POSCreditRepayments.Data.Repositories;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsData
    {
        IRepository<FinancialInstitution> FinancialInstitutions { get; }

        IRepository<Product> Products { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}