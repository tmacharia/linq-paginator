using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataAccess.Enums;
using Common;
using Dapper.Contrib.Extensions;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private IDbConnection _conn;

        public DataAccessLayer(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }

        public long Insert<T>(T entity)
            where T : class
        {
            return _conn.Insert(entity);
        }

        public T GetFirstOrDefault<T>() where T : class
        {
            return GetFirstOrDefault<T>(GetTableName<T>());
        }
        public T GetFirstOrDefault<T>(string tableName) where T : class
        {
            return _conn.QueryFirstOrDefault<T>($"select * from {tableName}");
        }
        public T GetFirstOrDefault<T>(Func<T, bool> predicate) where T : class
        {
            return GetAll<T>().FirstOrDefault(predicate);
        }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return GetAll<T>(GetTableName<T>());
        }
        public IEnumerable<T> GetAll<T>(string tableName)
            where T : class
        {
            if (!tableName.IsValid())
                throw new ArgumentNullException(nameof(tableName));
            
            string sql = $"select * from {tableName}";
            return _conn.Query<T>(sql);
        }
        public IEnumerable<T> GetAll<T, TKey>(Func<T, TKey> keySelector, OrderBy orderBy) 
            where T : class
        {
            return Order(GetAll<T>(), keySelector, orderBy);
        }
        public IEnumerable<T> GetAll<T, TKey>(string tableName, Func<T, TKey> keySelector, OrderBy orderBy) 
            where T : class
        {
            return Order(GetAll<T>(tableName), keySelector, orderBy);
        }
        public IEnumerable<T> GetAll<T>(string sp_name, object param)
        {
            return _conn.Query<T>(sp_name, new { param }, commandType: CommandType.StoredProcedure);
        }
        private IEnumerable<T> Order<T,TKey>(IEnumerable<T> enumerable, Func<T,TKey> keySelector, OrderBy orderBy)
            where T : class
        {
            return orderBy == OrderBy.Asc ?
                        enumerable.OrderBy(keySelector) :
                   orderBy == OrderBy.Desc ?
                        enumerable.OrderByDescending(keySelector) : enumerable;
        }
        private string GetTableName<T>()
        {
            var obj = typeof(T).GetAttributeValue<TableAttribute>(x => x.Name);
            return obj != null ? obj.ToString() : typeof(T).Name;
        }
    }
}
