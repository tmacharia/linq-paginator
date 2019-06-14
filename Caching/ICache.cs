using System;

namespace Caching
{
    public delegate void AddedEventHandler(string key, object obj);
    public delegate void RemovedEventHandler(string key);

    public interface ICache : IDisposable
    {
        event AddedEventHandler Added;
        event RemovedEventHandler Removed;

        void Add(string key, object value);
        bool Has(string key);
        bool HasExpired(string key);
        
        object GetCacheItem(string key);
        T GetCacheItem<T>(string key);
        void Remove(string key);
    }
}
