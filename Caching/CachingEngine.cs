using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Paginator.Models;

namespace Caching
{
    public class CachingEngine : ICachingEngine
    {
        #region Private Variables
        private readonly ICommonService _commonService;
        private readonly Random _random;

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
                    break;
                default:
                    break;
            }

            _random = new Random();
            // Initialize common service
            _commonService = new CommonService();
        }

        public HashSet<CacheComponent> CacheComponents
        {
            get
            {
                switch (_cacheType)
                {
                    case CacheType.Memory:
                        return _memCache;
                    case CacheType.Disk:
                        return _diskCache;
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
                Request = new Request()
                {
                    Page = result.Page,
                    ItemsPerPage = result.ItemsPerPage
                },
                Result = result,
            };

            AddComponent(component);

            return true;
        }

        public bool Add<T>(Request request, Result<T> result) where T : class
        {
            throw new NotImplementedException();
        }

        public bool ClearCache()
        {
            throw new NotImplementedException();
        }

        public Result<T> Get<T>(Request request) where T : class
        {
            throw new NotImplementedException();
        }

        public Result<T> Get<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public bool Remove<T>()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove<T>(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove<T>(Request request)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(Request request, Result<T> newResult) where T : class
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(Result<T> newResult) where T : class
        {
            throw new NotImplementedException();
        }

        #region Private Section
        private void AddComponent(CacheComponent component)
        {
            if (component == null)
                throw new ArgumentNullException("Cache Component.", "Component created was null. Unexpected error occured.");

            if(_cacheType == CacheType.Memory)
            {
                _memCache.Add(component);
            }
            else if(_cacheType == CacheType.Disk)
            {
                _diskCache.Add(component);
            }
        }
        #endregion
    }
}
