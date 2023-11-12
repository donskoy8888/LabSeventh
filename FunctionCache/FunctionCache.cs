public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public delegate TResult FuncDelegate(TKey key);

    public class CacheItem
    {
        public TResult Result { get; set; }
        public DateTime ExpirationTime { get; set; }
    }

    public TResult GetOrAdd(TKey key, FuncDelegate function, TimeSpan cacheDuration)
    {
        if (cache.TryGetValue(key, out var cacheItem) && cacheItem.ExpirationTime > DateTime.Now)
        {
            return cacheItem.Result;
        }

        TResult result = function(key);
        cache[key] = new CacheItem { Result = result, ExpirationTime = DateTime.Now.Add(cacheDuration) };

        return result;
    }

    public void ClearCache()
    {
        cache.Clear();
    }

    public bool RemoveFromCache(TKey key)
    {
        return cache.Remove(key);
    }

    public bool ContainsKey(TKey key)
    {
        return cache.ContainsKey(key);
    }

    public int GetCacheSize()
    {
        return cache.Count;
    }
}