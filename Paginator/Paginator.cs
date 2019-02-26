using Paginator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

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

        private static IDictionary<string, PropertyDescriptorCollection> _propsCache
            = new Dictionary<string, PropertyDescriptorCollection>();

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

        internal static PagedResult<T> ProcessPagination<T>(this IEnumerable<T> enumerable,
                    int page = _page, int perpage = _perpage)
        {
            int totalItems = enumerable.Count();

            return new PagedResult<T>()
            {
                page = page,
                perpage = perpage,
                total = totalItems,
                items = enumerable.Skip(GetStart(page)*perpage).Take(perpage).ToList()
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

            orderBy = orderBy.IsValid() ? orderBy : ResolveInCache<T>()[0].Name;

            elements = order == "asc" ? elements.OrderBy(x => x.GetPropValue(orderBy)) :
                       order == "desc" ? elements.OrderByDescending(x => x.GetPropValue(orderBy)) : elements;

            totalItems = elements.Count();


            PagedResult<T> result = new PagedResult<T>()
            {
                page = page,
                perpage = perpage,
                total = totalItems,
            };

            result.items = elements.Skip(GetStart(page) * perpage)
                                   .Take(perpage)
                                   .ToList();

            return result;
        }

        #region Private Region
        internal static int GetStart(int page) {
            return page - 1;
        }
        internal static string GetPropValue<T>(this T model, string propName)
            where T : class
        {
            string result = string.Empty;
            if (model == null)
                return result;

            var propertyDescriptor = ResolveInCache<T>()[propName];
            result = propertyDescriptor.GetValue(model).CastToString();
            return result;
        }
        internal static PropertyDescriptorCollection ResolveInCache<T>()
            where T : class
        {
            Type type = typeof(T);
            if (!_propsCache.ContainsKey(type.Name))
                _propsCache.Add(type.Name, TypeDescriptor.GetProperties(type));

            return _propsCache[type.Name];
        }
        #endregion
    }
}
