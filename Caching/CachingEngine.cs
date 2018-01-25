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
            throw new NotImplementedException();
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
    }
}
