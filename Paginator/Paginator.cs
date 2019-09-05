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
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.ProcessPagination(_page, _perpage);
        }
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, 
            int page=_page, int perpage=_perpage)
            where T : class
        {
            return enumerable.ProcessPagination(page,perpage);
        }
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
        {
            return enumerable.ProcessPagination(predicate);
        }
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate,
            int page=_page, int perpage=_perpage)
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage);
        }
        public static PagedResult<T> Paginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, 
            int page=_page, int perpage=_perpage, string orderBy = null, string order = "asc")
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        }
        #endregion

        #region .Page Methods
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.ProcessPagination(_page, _perpage);
        }
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(page, perpage);
        }
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
        {
            return enumerable.ProcessPagination(predicate);
        }
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage);
        }
        public static PagedResult<T> Page<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        }
        #endregion

        #region .Paged Methods
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.ProcessPagination(_page, _perpage);
        }
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(page, perpage);
        }
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
        {
            return enumerable.ProcessPagination(predicate);
        }
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage);
        }
        public static PagedResult<T> Paged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        }
        #endregion

        #region .ToPages Methods
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.ProcessPagination(_page, _perpage);
        }
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(page, perpage);
        }
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
        {
            return enumerable.ProcessPagination(predicate);
        }
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage);
        }
        public static PagedResult<T> ToPages<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        }
        #endregion

        #region .ToPaginate Methods
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.ProcessPagination(_page, _perpage);
        }
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(page, perpage);
        }
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            where T : class
        {
            return enumerable.ProcessPagination(predicate);
        }
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage)
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage);
        }
        public static PagedResult<T> ToPaginate<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate,
            int page = _page, int perpage = _perpage, string orderBy = null, string order = "asc")
            where T : class
        {
            return enumerable.ProcessPagination(predicate, page, perpage, orderBy, order);
        }
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
