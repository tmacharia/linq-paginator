using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Threading;
using Caching.Enums;

namespace Caching
{
    public class MemoryCache : IBaseInterface, ICache
    {
        private IDictionary<string, CacheItem> _dictionary;
        private TimeSpan _span;
        private readonly Timer _timer;
        private CacheState _state;

        #region Event Handlers
        public event AddedEventHandler Added;
        public event RemovedEventHandler Removed;
        #endregion


        public MemoryCache(double cacheDuration=30)
            :this(TimeSpan.FromSeconds(cacheDuration))
        {

        }

        public MemoryCache(TimeSpan period)
        {
            _span = period;
            _dictionary = new SortedDictionary<string, CacheItem>();
            _timer = new Timer(state => OnTick(), null, period, period);
        }

        private void OnTick() {
            CheckCacheState();
            SetCacheState(CacheState.Cleanup);
            lock (_dictionary) {
                for (int i = 0; i < _dictionary.Count; i++) {
                    var item = _dictionary.ElementAt(i);
                    if (item.Value.HasExpired)
                        Remove(item.Key);
                }
            }
            SetCacheState(CacheState.Open);
        }
        private void CheckCacheState()
        {
            if (_state != CacheState.Open)
                WaitTillOpen();
        }
        private void WaitTillOpen() {
            while (_state != CacheState.Open) {
                Thread.Sleep(2);
            }
        }
        private void SetCacheState(CacheState state) => _state = state;

        public void Add(string key, object item)
        {
            CheckCacheState();

            if (Has(key)) {
                Remove(key);
            }

            SetCacheState(CacheState.Writing);
            _dictionary.Add(key, new CacheItem(key, item,_span));
            Added?.Invoke(key, item);
            SetCacheState(CacheState.Open);
        }

        public object GetCacheItem(string key)
        {
            CheckCacheState();

            SetCacheState(CacheState.Reading);
            lock (_dictionary)
            {
                _dictionary.TryGetValue(key, out CacheItem cacheItem);
                SetCacheState(CacheState.Open);
                return cacheItem.IsNotNull() ? cacheItem.Value : null;
            }
        }

        public T GetCacheItem<T>(string key)  => (T)GetCacheItem(key);

        public bool HasExpired(string key)
        {
            _dictionary.TryGetValue(key, out CacheItem cacheItem);
            return cacheItem.IsNotNull() ? cacheItem.HasExpired : true;
        }
        public bool Has(string key) => _dictionary.ContainsKey(key);

        public void Remove(string key) {
            _dictionary.Remove(key);
            Removed?.Invoke(key);
        }

        protected override void Dispose(bool isDisposing) {
            if (isDisposing) {
                _dictionary.Clear();
                _dictionary = null;
            }
            else {
                _dictionary.Clear();
            }
            base.Dispose(isDisposing);
        }
    }
}
