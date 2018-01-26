using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Paginator.Models;
using System.Linq.Expressions;

namespace Caching
{
    public class CachingEngine : ICachingEngine, IDisposable
    {
        #region Private Variables
        private static ICommonService _commonService;
        private static string _cache;
        private static Random _random;

        private HashSet<CacheComponent> _memCache;
        private HashSet<CacheComponent> _diskCache;
        private readonly CacheType _cacheType;
        #endregion

        public CachingEngine(CacheType cacheType)
        {
            _cacheType = cacheType;

            switch (cacheType)
            {
                case CacheType.Memory:
                    _memCache = new HashSet<CacheComponent>();
                    break;
                case CacheType.Disk:
                    _diskCache = new HashSet<CacheComponent>();
                    _cache = "cache";
                    break;
                default:
                    break;
            }

            _random = new Random();
            // Initialize common service
            _commonService = new CommonService();
            _commonService.Initialize();
        }

        public CacheComponent[] CacheComponents
        {
            get
            {
                switch (_cacheType)
                {
                    case CacheType.Memory:
                        return _memCache?.ToArray();
                    case CacheType.Disk:
                        return _diskCache?.ToArray();
                    default:
                        return null;
                }
            }
        }


        public bool Add<T>(Result<T> result) where T : class
        {
            CacheComponent component = new CacheComponent()
            {
                Id = _random.Next(),
                Type = typeof(T),
                Result = result,
            };

            return AddComponent(component);
        }

        public Result<T> Get<T>() where T : class
        {
            return GetComponent<T>(typeof(T), null);
        }
        public Result<T> Get<T>(int id) where T : class
        {
            return GetComponent<T>(null, id);
        }

        public bool Remove<T>() where T : class
        {
            RemoveComponent<T>(typeof(T), null);

            return true;
        }
        public bool Remove<T>(int id)
            where T : class
        {
            RemoveComponent<T>(typeof(T), id);

            return true;
        }
        public bool Update<T>(Result<T> newResult) where T : class
        {
            return UpdateComponent(newResult);
        }

        public bool ClearCache()
        {
            if(_cacheType == CacheType.Disk)
            {
                Console.WriteLine("Clearing Disk cache...");

                bool result = _commonService.Clear(_cache);

                Console.WriteLine("DONE!!");

                return true;
            }else if(_cacheType == CacheType.Memory)
            {
                Console.WriteLine("Clearing Memory cache...");

                _memCache = null;

                Console.WriteLine("DONE!!");

                return true;
            }

            return false;
        }
        public void Dispose()
        {
            // Save to file
            if(_cacheType == CacheType.Disk)
            {
                _commonService.Write<HashSet<CacheComponent>>(_diskCache, _cache);
            }

            // Dispose objects
            _cache = string.Empty;
            _random = null;
            _commonService = null;
            _memCache = null;
            _diskCache = null;
        }


        #region Private Section
        private bool AddComponent(CacheComponent component)
        {
            if (component == null)
                throw new ArgumentNullException("Cache Component.", "Component created was null. Unexpected error occured.");

            if(_cacheType == CacheType.Memory)
            {
                return _memCache.Add(component);
            }
            else if(_cacheType == CacheType.Disk)
            {
                return _diskCache.Add(component);
            }

            return false;
        }
        private Result<T> GetComponent<T>(Type type, int? id)
            where T : class
        {
            if (_cacheType == CacheType.Memory)
            {
                CacheComponent cacheComponent = null;

                if(type != null)
                {
                    cacheComponent = _memCache.FirstOrDefault(x => x.Type == type);
                }
                else if(id != null || id != 0)
                {
                    cacheComponent = _memCache.FirstOrDefault(x => x.Id == id.Value);
                }

                if (cacheComponent != null)
                {
                    return (Result<T>)cacheComponent.Result;
                }
                else
                {
                    return null;
                }
            }
            else if (_cacheType == CacheType.Disk)
            {
                CacheComponent cacheComponent = null;

                if (type != null)
                {
                    cacheComponent = _diskCache.FirstOrDefault(x => x.Type == type);
                }
                else if (id != null || id != 0)
                {
                    cacheComponent = _diskCache.FirstOrDefault(x => x.Id == id.Value);
                }

                if (cacheComponent != null)
                {
                    return (Result<T>)cacheComponent.Result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private void RemoveComponent<T>(Type type, int? id)
            where T : class
        {
            if (_cacheType == CacheType.Memory)
            {
                if (type != null)
                {
                    _memCache.RemoveWhere(x => x.Type == type);
                }

                if (id != null || id != 0)
                {
                    _memCache.RemoveWhere(x => x.Id == id.Value);
                }
            }
            else if (_cacheType == CacheType.Disk)
            {
                if (type != null)
                {
                    _diskCache.RemoveWhere(x => x.Type == type);
                }

                if (id != null || id != 0)
                {
                    _diskCache.RemoveWhere(x => x.Id == id.Value);
                }
            }
        }
        private bool UpdateComponent<T>(Result<T> newResult)
            where T : class
        {
            if (_cacheType == CacheType.Memory)
            {
                CacheComponent cacheComponent = null;

                cacheComponent = _memCache.FirstOrDefault(x => x.Type == typeof(T));

                if (cacheComponent != null)
                {
                    // Clone component
                    var newCache = cacheComponent;

                    // Remove existing component from collection
                    _memCache.Remove(cacheComponent);

                    //update cloned component
                    newCache.UpdatedTime = DateTime.Now;
                    newCache.Result = newResult;

                    // Add new component to collection
                    return _memCache.Add(newCache);
                }
                else
                {
                    return Add(newResult);
                }
            }
            else if (_cacheType == CacheType.Disk)
            {
                CacheComponent cacheComponent = null;

                cacheComponent = _diskCache.FirstOrDefault(x => x.Type == typeof(T));

                if (cacheComponent != null)
                {
                    // Clone component
                    var newCache = cacheComponent;

                    // Remove existing component from collection
                    _diskCache.Remove(cacheComponent);

                    //update cloned component
                    newCache.UpdatedTime = DateTime.Now;
                    newCache.Result = newResult;

                    // Add new component to collection
                    return _diskCache.Add(newCache);
                }
                else
                {
                    return Add(newResult);
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
