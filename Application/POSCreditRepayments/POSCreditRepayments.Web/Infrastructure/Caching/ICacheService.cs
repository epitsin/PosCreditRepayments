using System;

namespace POSCreditRepayments.Web.Infrastructure.Caching
{
    public interface ICacheService
    {
        void Clear(string cacheId);

        T Get<T>(string cacheID, Func<T> getItemCallback) where T : class;
    }
}