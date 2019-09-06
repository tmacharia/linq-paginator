using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paginator
{
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

        #region .Paginate Methods
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable)
            where T : class 
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="page">The page to retrive</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, 
            int page=_page, int perpage=_perpage)
            where T : class 
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .Page Methods
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .Paged Methods
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .ToPages Methods
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        #region .ToPaginate Methods
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable)
            where T : class
            => enumerable.ProcessPagination(_page, _perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
            => enumerable.ProcessPagination(predicate);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage);
        /// <summary>
        /// Paginate this collection into pages of 10 items each.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="enumerable">The current collection.</param>
        /// <param name="predicate">A filter to apply to the collection before pagination.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perpage">Number of items per page.</param>
        /// <param name="orderBy">Property to order by</param>
        /// <param name="order">Ordering type e.g asc or desc</param>
        /// <returns>Paginated collection.</returns>
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
            => enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        #endregion

        internal static PagedResult<T> ProcessPagination<T>(this IEnumerable<T> enumerable,
                    int page = _page, int perpage = _perpage)
        {
            int totalItems = enumerable.Count();

            return new PagedResult<T>()
            {
                Page = page,
                ItemsPerPage = perpage,
                TotalItems = totalItems,
                TotalPages = CalculateTotalPages(totalItems,perpage),
                List = enumerable.Skip(GetStart(page)*perpage).Take(perpage).ToArray()
            };
        }
        internal static PagedResult<T> ProcessPagination<T>(this IEnumerable<T> enumerable,
            Func<T, bool> predicate=null, int page = _page, int perpage = _perpage, string orderBy = null,
            string order = "asc") where T : class
        {
            int totalItems = 0;
            IEnumerable<T> elements;

            elements = predicate != null ?
                        enumerable.Where(predicate) :
                        enumerable;

            orderBy = orderBy.IsValid() ? orderBy : typeof(T).GetPropertyDescriptors()[0].Name;

            elements = order == "asc" ? elements.OrderBy(x => x.GetPropertyValue<T,object>(orderBy)) :
                       order == "desc" ? elements.OrderByDescending(x => x.GetPropertyValue<T,object>(orderBy)) : elements;

            totalItems = elements.Count();


            PagedResult<T> result = new PagedResult<T>()
            {
                Page = page,
                ItemsPerPage = perpage,
                TotalItems = totalItems,
                TotalPages = CalculateTotalPages(totalItems,perpage)
            };

            result.List = elements.Skip(GetStart(page) * perpage)
                                   .Take(perpage)
                                   .ToArray();

            return result;
        }

        #region Private Region
        internal static int GetStart(int page) {
            return page - 1;
        }
        internal static int CalculateTotalPages(int totalItems, int perpage)
        {
            int ans = 0;
            if (perpage < 1)
                return ans;
            ans = totalItems / perpage;
            ans += totalItems % perpage;
            return ans;
        }
        #endregion
    }
}
