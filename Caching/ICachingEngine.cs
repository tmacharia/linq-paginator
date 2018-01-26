using Paginator.Models;
using System;
using System.Collections.Generic;

namespace Caching
{
    /// <summary>
    /// Service that allows caching of repeated pagination requests for easier
    /// & faster retreival of data.
    /// </summary>
    public interface ICachingEngine
    {
        /// <summary>
        /// All cache component pointers for the current Caching Engine.
        /// </summary>
        CacheComponent[] CacheComponents { get; }

        bool Add<T>(Result<T> result) where T : class;
        bool Update<T>(Result<T> newResult) where T : class;


        Result<T> Get<T>() where T : class;
        Result<T> Get<T>(int id) where T : class;


        bool Remove<T>() where T : class;
        bool Remove<T>(int id) where T : class;

        bool ClearCache();
        void Dispose();
    }
}
