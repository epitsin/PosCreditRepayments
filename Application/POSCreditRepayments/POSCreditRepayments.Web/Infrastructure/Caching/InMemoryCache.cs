using System;
using System.Web;
using System.Web.Caching;

namespace POSCreditRepayments.Web.Infrastructure.Caching
{
    public class InMemoryCache : ICacheService
    {
        public void Clear(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }

        public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheID) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Insert(cacheID, item, null, DateTime.Now.AddMinutes(15), Cache.NoSlidingExpiration);
            }
            return item;
        }
    }
}