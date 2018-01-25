using Paginator.Models;
using System;

namespace Paginator.Caching
{
    /// <summary>
    /// Service that allows caching of repeated pagination requests for easier
    /// & faster retreival of data.
    /// </summary>
    public interface ICachingEngine
    {
        bool Add<T>(Result<T> result) where T : class;
        bool Add<T>(Request request, Result<T> result) where T : class;
        bool Update<T>(Request request, Result<T> newResult) where T : class;
        bool Update<T>(Result<T> newResult) where T : class;


        Result<T> Get<T>(Request request) where T : class;
        Result<T> Get<T>(int id) where T : class;


        bool Remove<T>();
        bool Remove(int id);
        bool Remove<T>(int id);
        bool Remove<T>(Request request);

        bool ClearCache();
    }
}
