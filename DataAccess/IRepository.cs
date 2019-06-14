using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Returns the total number of <see cref="T"/> in its
        /// <see cref="Repository"/>
        /// </summary>
        int Count { get; }
        T First { get; }
        Task<T> FirstAsync { get; }
        /// <summary>
        /// Get A List of all objects in repository
        /// as an IEnumerable
        /// </summary>
        IQueryable<T> List { get; }
        Task<List<T>> ListAsync { get; }
        IQueryable<T> ListWith<TProperty>(Expression<Func<T, TProperty>> navPropertyPath);
        /// <summary>
        /// Update the current entity in the specified repository by
        /// the generic class T
        /// </summary>
        /// <param name="entity">Object with new updated values</param>
        /// <returns>An updated object</returns>
        T Update(T entity);
        T[] UpdateMany(T[] entitie);

        /// <summary>
        /// Add a new item in the repository
        /// </summary>
        /// <param name="entity">Object entity to add in the repository</param>
        /// <returns>A newly created object after saving in the database</returns>
        T Create(T entity);
        T[] CreateMany(T[] entities);
        /// <summary>
        /// Get an object by its primary key
        /// </summary>
        /// <param name="id">[Primary Key], Id</param>
        /// <returns>Object instance as found in the repository. Null if it does not exist.</returns>
        T GetById(int id);
        T GetById(Guid uuid);
        T GetWith<TProperty>(int id, Expression<Func<T, TProperty>> navPropertyPath);
        /// <summary>
        /// Retrieves the first entity of type <see cref="T"/> that satisfies the <paramref name="predicate"/>
        /// function specified including the specified <paramref name="navPropertyPath"/> of type 
        /// <typeparamref name="TProperty"/>.
        /// 
        /// </summary>
        /// <typeparam name="TProperty"><see cref="Type"/> of property to include with the result.</typeparam>
        /// <param name="navPropertyPath">Path to the property to include.</param>
        /// <param name="predicate">Filter of what item to select.</param>
        /// <returns>
        /// <see cref="null"/> if the entity is not found and returns an object of <see cref="Type"/> <see cref="T"/>
        /// if found.
        /// </returns>
        T GetWith<TProperty>(Expression<Func<T, TProperty>> navPropertyPath, Func<T, bool> predicate);
        /// <summary>
        /// Get an object in a repository using a Func expression
        /// with a uuid for the object in question
        /// </summary>
        /// <param name="uuidExpression">Func Expression, specify a uuid</param>
        /// <returns>A found object</returns>
        T GetByGuid(Func<T, bool> uuidExpression);
        /// <summary>
        /// Gets an object from the repository based on the full object
        /// </summary>
        /// <param name="entity">The object to look for.</param>
        /// <returns>Found object. Null if not found</returns>
        T GetByObject(T entity);
        /// <summary>
        /// Gets an object from the repository based on a string key value
        /// 
        /// e.g email
        /// </summary>
        /// <param name="stringExpression">Func Expression containing a key as a string</param>
        /// <returns>Found object. Null if not found</returns>
        T GetWhere(Func<T, bool> stringExpression);
        /// <summary>
        /// Gets a list of object that matches the predicate passed in here
        /// </summary>
        /// <param name="expression">Predicate as an expression func of any type</param>
        /// <returns>An IEnumerable of all objects matching search predicate</returns>
        //IEnumerable<T> Get(Func<T, bool> expression);

        bool Remove(T entity);
        bool Remove(int id);
        bool RemoveMany(int[] ids);
        bool RemoveMany(T[] entities);
    }
}
