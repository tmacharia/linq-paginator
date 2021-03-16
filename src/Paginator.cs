using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paginator
{
    /// <summary>
    /// Represents a static class containing functions &amp; methods for doing pagination.
    /// </summary>
    public static class Paginator
    {
        /// <summary>
        /// Default start page
        /// </summary>
        private const int _page = 1;
        /// <summary>
        /// Number of items to return per page.
        /// </summary>
        private const int _perpage = 10;
        private const bool _skipCount = false;

        #region .Paginate Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable)
            where T : class 
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="skipCount">Whether to avoid running count query &amp; only get required items.</param>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage, bool skipCount = _skipCount)
            where T : class
            => enumerable.ProcessPagination(page, perpage, skipCount);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .Page Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .Paged Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .ToPages Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .ToPaginate Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="T">Type of entity in collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region IQueryable Methods
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> Page<TEntity>(this IQueryable<TEntity> entities)
            where TEntity : class
            => entities.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> Page<TEntity>(this IQueryable<TEntity> entities,
            int page = _page, int perpage = _perpage)
            where TEntity : class
            => entities.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> Paged<TEntity>(this IQueryable<TEntity> entities)
            where TEntity : class
            => entities.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> Paged<TEntity>(this IQueryable<TEntity> entities,
            int page = _page, int perpage = _perpage)
            where TEntity : class
            => entities.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> ToPages<TEntity>(this IQueryable<TEntity> entities)
            where TEntity : class
            => entities.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        [Obsolete("Use .Paginate instead")]
        public static PagedResult<TEntity> ToPages<TEntity>(this IQueryable<TEntity> entities,
            int page = _page, int perpage = _perpage)
            where TEntity : class
            => entities.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities)
            where TEntity : class
            => entities.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of (x) items each and returns only the first subset.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="skipCount">Whether to avoid running count query &amp; only get required items.</param>
        /// <param name="entities">The current collection.</param>
        /// <returns><see cref="PagedResult{T}"/>.</returns>
        public static PagedResult<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities,
            int page = _page, int perpage = _perpage, bool skipCount = _skipCount)
            where TEntity : class
            => entities.ProcessPagination(page, perpage, skipCount);
        #endregion

        internal static PagedResult<TEntity> ProcessPagination<TEntity>(this IQueryable<TEntity> query,
                    int page = _page, int perpage = _perpage, bool skipCount = _skipCount)
        {
            int total = 0;
            var list = new List<TEntity>();

            if (!skipCount)
                total = query.CountEntities();

            if (skipCount || (!skipCount && total > 0))
                list = query.Skip((page - 1) * perpage).Take(perpage).ToList();

            if (skipCount)
                total = list.Count;

            return new PagedResult<TEntity>()
            {
                Page = page,
                ItemsPerPage = perpage,
                TotalItems = total,
                TotalPages = CalculateTotalPages(total, perpage),
                Items = list
            };
        }
        internal static PagedResult<T> ProcessPagination<T>(this IEnumerable<T> enumerable,
                    int page = _page, int perpage = _perpage, bool skipCount = _skipCount)
        {
            int total = 0;
            var list = new List<T>();

            if (!skipCount)
                total = enumerable.CountItems();

            if (skipCount || (!skipCount && total > 0))
                list = enumerable.Skip((page - 1) * perpage).Take(perpage).ToList();

            if (skipCount)
                total = list.Count;

            return new PagedResult<T>()
            {
                Page = page,
                ItemsPerPage = perpage,
                TotalItems = total,
                TotalPages = CalculateTotalPages(total, perpage),
                Items = list
            };
        }
        internal static PagedResult<T> ProcessPagination<T>(this IEnumerable<T> enumerable,
            Func<T, bool> predicate=null, int page = _page, int perpage = _perpage, string orderBy = null,
            string order = "asc") where T : class
        {
            int total = 0;
            IEnumerable<T> query;

            query = predicate != null ? enumerable.Where(predicate) : enumerable;
            if (orderBy.IsValid())
            {
                query = order == "asc" ? query.OrderBy(x => x.GetPropertyValue<T, object>(orderBy)) :
                       order == "desc" ? query.OrderByDescending(x => x.GetPropertyValue<T, object>(orderBy)) : query;
            }

            total = query.CountItems();


            PagedResult<T> result = new PagedResult<T>()
            {
                Page = page,
                ItemsPerPage = perpage,
                TotalItems = total,
                TotalPages = CalculateTotalPages(total, perpage)
            };

            result.Items = query.Skip((page - 1) * perpage).Take(perpage).ToList();

            return result;
        }

        #region Private Region
        internal static int CountEntities<TEntity>(this IQueryable<TEntity> entities)
        {
            return entities.Count();
        }
        internal static int CountItems<TEntity>(this IEnumerable<TEntity> enumerable)
        {
            return enumerable.Count();
        }
        internal static int CalculateTotalPages(int totalItems, int perpage)
        {
            int ans = 0;
            if (perpage >= 1) {
                ans = totalItems / perpage;
                ans += (totalItems % perpage) > 0 ? 1 : 0;
                return ans;
            }
            return ans;
        }
        #endregion
    }
}