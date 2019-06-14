using System;
using System.Collections.Generic;
using DataAccess.Enums;

namespace DataAccess
{
    public interface IDataAccessLayer
    {
        long Insert<T>(T entity)
            where T : class;

        T GetFirstOrDefault<T>()
            where T : class;
        T GetFirstOrDefault<T>(string tableName)
            where T : class;
        T GetFirstOrDefault<T>(Func<T, bool> predicate)
            where T : class;


        IEnumerable<T> GetAll<T>() 
            where T : class;
        IEnumerable<T> GetAll<T>(string tableName) 
            where T : class;
        IEnumerable<T> GetAll<T, TKey>(Func<T, TKey> keySelector, OrderBy orderBy) 
            where T : class;
        IEnumerable<T> GetAll<T, TKey>(string tableName, Func<T, TKey> keySelector, OrderBy orderBy)
            where T : class;
        IEnumerable<T> GetAll<T>(string sp_name, object param);
    }
}
