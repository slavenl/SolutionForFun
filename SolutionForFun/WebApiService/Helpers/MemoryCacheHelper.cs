using Microsoft.Extensions.Caching.Memory;

namespace WebApiService.Helpers
{
    public static class MemoryCacheHelper
    {
        /// <summary>
        /// Custom extension method for adding specific memory entry to cache object
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Add(this IMemoryCache memoryCache, string key, object value)
        {
            if (memoryCache.Get(key) == null)
            {
                memoryCache.CreateEntry(key);
            }

            memoryCache.Set(key, value);

        }

        /// <summary>
        /// Custom extension method for removing specific memory entry from cache object
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <param name="key"></param>
        public static void Delete(this IMemoryCache memoryCache, string key)
        {
            if (memoryCache.Get(key) != null)
            {
                memoryCache.Remove(key);
            }
        }
    }
}
