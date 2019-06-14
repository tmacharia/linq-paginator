using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Exceptional;

namespace Paginator
{
    /// <summary>
    /// Paginator contains all the extension methods to enable <see cref="System.Linq"/> default
    /// collections such as: <see cref="IQueryable"/>, <see cref="IEnumerable{T}"/>, <see cref="IList{T}"/>,
    /// <see cref="ICollection{T}"/>, <see cref="List{T}"/> have an extra method on them that
    /// paginates their collections they want.
    /// 
    /// <exception cref="InvalidArgumentException">Thrown when logically in-correct values are used
    /// in a pagination request.
    /// </exception>
    /// 
    /// <exception cref="OutOfRangeException">Thrown when a pagination request requires a certain page
    /// that is not within the range of allowable total pages or using non-negative integer values.
    /// </exception>
    /// </summary>
    public static class Paginator
    {
        #region Default Private Variables
        /// <summary>
        /// Default start page for pagination in-case no start page is defined.
        /// </summary>
        private const int _startPage = 0;
        /// <summary>
        /// Default number of items to return per page in-case no value is passed
        /// by the developer.
        /// </summary>
        private const int _items_per_page = 10;
        #endregion

        #region IEnumerable Extensions
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to page.</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            PaginationRequest request = Validate(enumerable, null);

            return Process(enumerable, null, request.Page, request.ItemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to page.</param>
        /// <param name="page">Page number to retreive contents from.</param>
        /// <param name="itemsPerPage">Number of items to return in every page. e.g 10,20,30 e.t.c</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IEnumerable<T> enumerable, int page, int itemsPerPage)
            where T : class
        {
            Validate(enumerable, page, itemsPerPage);

            return Process(enumerable, null, page, itemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to page.</param>
        /// <param name="predicate">A lambda expression to filter data from the main
        /// <see cref="IEnumerable{T}"/> collection.
        /// </param>
        /// <param name="page">Page number to retreive contents from.</param>
        /// <param name="itemsPerPage">Number of items to return in every page. e.g 10,20,30 e.t.c</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IEnumerable<T> enumerable,Func<T,bool> predicate, int page, int itemsPerPage)
            where T : class
        {
            Validate(enumerable, page, itemsPerPage);

            return Process(enumerable, predicate, page, itemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to page.</param>
        /// <param name="request">A <see cref="PaginationRequest"/> object describing a pagination
        /// request with the following options: Page and items per page
        /// </param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IEnumerable<T> enumerable, PaginationRequest request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, null, request.Page, request.ItemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to page.</param>
        /// <param name="predicate">A lambda expression to filter data from the main
        /// <see cref="IEnumerable{T}"/> collection.</param>
        /// <param name="request">A <see cref="PaginationRequest"/> object describing a pagination
        /// request with the following options: Page and items per page
        /// </param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, PaginationRequest request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, predicate, request.Page, request.ItemsPerPage);
        }
        #endregion


        #region IQueryable Extensions
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="queryable"><see cref="IQueryable{T}"/> collection to page.</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IQueryable<T> queryable)
            where T : class
        {
            PaginationRequest request = Validate(queryable, null);

            return Process(queryable, null, request.Page, request.ItemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="queryable"><see cref="IQueryable{T}"/> collection to page.</param>
        /// <param name="page">Page number to retreive contents from.</param>
        /// <param name="itemsPerPage">Number of items to return in every page. e.g 10,20,30 e.t.c</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IQueryable<T> queryable,int page,int itemsPerPage)
            where T : class
        {
            Validate(queryable, page, itemsPerPage);

            return Process(queryable, null, page, itemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="queryable"><see cref="IQueryable{T}"/> collection to page.</param>
        /// <param name="predicate">A lambda expression to filter data from the main
        /// <see cref="IQueryable{T}"/> collection.
        /// </param>
        /// <param name="page">Page number to retreive contents from.</param>
        /// <param name="itemsPerPage">Number of items to return in every page. e.g 10,20,30 e.t.c</param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IQueryable<T> queryable, Func<T, bool> predicate, int page, int itemsPerPage)
                where T : class
        {
            Validate(queryable, page, itemsPerPage);

            return Process(queryable, predicate, page, itemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="queryable"><see cref="IQueryable{T}"/> collection to page.</param>
        /// <param name="request">A <see cref="PaginationRequest"/> object describing a pagination
        /// request with the following options: Page and items per page
        /// </param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IQueryable<T> queryable, PaginationRequest request)
            where T : class
        {
            request = Validate(queryable, request);

            return Process(queryable, null, request.Page, request.ItemsPerPage);
        }
        /// <summary>
        /// Page an enumerable collection into manageable pages that you can to retreive
        /// items you need in chunks in a very efficient way.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="queryable"><see cref="IQueryable{T}"/> collection to page.</param>
        /// <param name="predicate">A lambda expression to filter data from the main
        /// <see cref="IQueryable{T}"/> collection.</param>
        /// <param name="request">A <see cref="PaginationRequest"/> object describing a pagination
        /// request with the following options: Page and items per page
        /// </param>
        /// <returns>A <see cref="PagedResult{T}"/> object with the current page number,
        /// total items, total pages and an array (x) of items.
        /// </returns>
        public static PagedResult<T> ToPaged<T>(this IQueryable<T> queryable, Func<T, bool> predicate, PaginationRequest request)
            where T : class
        {
            request = Validate(queryable, request);

            return Process(queryable, predicate, request.Page, request.ItemsPerPage);
        }
        #endregion

        #region Main Processing Region
        /// <summary>
        /// This is the main function that processes all pagination requests.
        /// </summary>
        /// <typeparam name="T">Type of object in IEnumerable. Must be a class</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to use.</param>
        /// <param name="predicate">A lambda expression that points to a <see cref="Func{T, TResult}"/>
        /// delegate to filter the <paramref name="enumerable"/> further.
        /// </param>
        /// <param name="page">Page to return with its items.</param>
        /// <param name="itemsPerPage">Number of items to put in every page.</param>
        /// <returns>
        /// A pagination <see cref="PagedResult{T}"/> with the expected results.
        /// </returns>
        /// <exception cref="OutOfRangeException">Thrown when the requested page number
        /// is greater than the total number of pages.
        /// </exception>
        private static PagedResult<T> Process<T>(IEnumerable<T> enumerable, Func<T, bool> predicate, int page, int itemsPerPage)
            where T : class
        {
            IEnumerable<T> elements = Enumerable.Empty<T>();
            
            if (predicate == null)
                elements = enumerable;
            else
                elements = enumerable.Where(predicate);

            int total = elements.Count();

            PagedResult<T> result = new PagedResult<T>
            {
                ItemsPerPage = itemsPerPage,
                TotalItems = total,
                Page = page,
                TotalPages = TotalPages(total, itemsPerPage),
            };
            
            // Checks correctness of page requested and continues to put the items from
            // that page in the result object list.
            if (result.Page > result.TotalPages)
                throw new OutOfRangeException(result.Page, result.TotalPages);
            else if (result.Page == result.TotalPages)
                result.List = GetCurrentItems(elements, page, itemsPerPage, true, LastPageCount(total, itemsPerPage));
            else
                result.List = GetCurrentItems(elements, page, itemsPerPage, false);

            return result;
        }
        #endregion

        #region Private Section
        /// <summary>
        /// Checks for errors in parameters/arguments used in a pagination request and throws 
        /// relevant <see cref="Exceptions"/> to stop further processing. If the request object 
        /// provided is null, a request of type <see cref="PaginationRequest"/> is created with default
        /// values: 
        /// 
        /// </summary>
        /// <example>
        ///     Page : 1,
        ///     ItemsPerPage: 10
        /// </example>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to validate</param>
        /// <param name="request"><see cref="PaginationRequest"/> object defining pagination rules.</param>
        /// <returns>A validated <see cref="PaginationRequest"/> object.
        /// </returns>
        /// <exception cref="NullCollectionException">Throws when <paramref name="enumerable"/>
        /// provided is null.
        /// </exception>
        /// <exception cref="InvalidArgumentException">Throws when either parameters in <paramref name="request"/>
        /// object are wrong or negative numbers.
        /// </exception>
        private static PaginationRequest Validate<T>(IEnumerable<T> enumerable, PaginationRequest? request)
        {
            if (enumerable == null)
                throw new NullCollectionException(nameof(enumerable));

            if (!request.HasValue) {
                request = new PaginationRequest(Globals.Page + 1, Globals.PerPage);
            }
            else {
                if (request.Value.Page < 0 || request.Value.ItemsPerPage < 0)
                    throw new InvalidArgumentException("PaginationRequest.Page", "PaginationRequest.ItemsPerPage");
            }
            return request.Value;
        }
        /// <summary>
        /// Checks for errors in parameters/arguments used in a pagination request and throws 
        /// relevant <see cref="Exceptions"/> to stop further processing.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to validate.</param>
        /// <param name="page">Page number to return.</param>
        /// <param name="perpage">Number of items to put in every page.</param>
        /// <exception cref="NullCollectionException">Throws when <paramref name="enumerable"/>
        /// provided is null.
        /// </exception>
        /// <exception cref="InvalidArgumentException">Throws when either parameters <paramref name="page"/>
        /// or <paramref name="perpage"/> are wrong or negative numbers.
        /// </exception>
        private static void Validate<T>(IEnumerable<T> enumerable, int page,int perpage)
        {
            if (enumerable == null)
                throw new NullCollectionException("enumerable");

            if (page < 0 || perpage < 0)
                throw new InvalidArgumentException("page", "perpage");
        }
        /// <summary>
        /// Gets the total number of pages required to page/package pagination request
        /// results.
        /// 
        /// </summary>
        /// <param name="total">Total number of items to be paged.</param>
        /// <param name="perpage">Number of items to put in every page.</param>
        /// <returns>Total number of pages required to page all items.</returns>
        private static int TotalPages(int total, int perpage)
        {
            int n = (total / perpage);

            if (LastPageCount(total,perpage) > 0)
                n++;

            return n;
        }
        /// <summary>
        /// Gets the number of items remaining in the last page that is less than
        /// the requested <paramref name="perpage"/> value.
        /// 
        /// </summary>
        /// <param name="total">Total number of items to be paged.</param>
        /// <param name="perpage">Number of items to put in every page.</param>
        /// <returns>Number of items in the last page.</returns>
        private static int LastPageCount(int total,int perpage) => (total % perpage);
        /// <summary>
        /// Logs the results of a pagination request to the console or any logger
        /// attached.
        /// </summary>
        /// <typeparam name="T">Type of object that the result contains.</typeparam>
        /// <param name="result">An object of Type <see cref="PagedResult{T}"/> that contains
        /// all the pagination information:
        /// 
        /// <list type="bullet">
        ///     <listheader>All properties in <typeparamref name="T"/></listheader>
        ///     <item><see cref="PagedResult{T}.Page"/> -> CurrentPage/Requested page</item>
        ///     <item><see cref="PagedResult{T}.TotalPages"/> -> All pages with all the items.</item>
        ///     <item><see cref="PagedResult{T}.ItemsPerPage"/> -> Number of items in every page.</item>
        ///     <item><see cref="PagedResult{T}.List"/> -> List with items in page x.</item>
        ///     <item><see cref="PagedResult{T}.TotalItems"/> -> Total number of items paged.</item>
        /// </list>
        /// </param>
        //private static void Log<T>(PagedResult<T> result)
        //    where T : class
        //{
        //    Debug.WriteLine("\n========\nResult object:\n=========\n");
        //    Debug.WriteLine("Current Page: {0}", result.Page.ToString(Format.Number));
        //    Debug.WriteLine("Total Pages: {0}", result.TotalPages.ToString(Format.Number));
        //    Debug.WriteLine("Items per page: {0}", result.ItemsPerPage.ToString(Format.Number));
        //    Debug.WriteLine("Total items in current array: {0}", result.List.Count.ToString(Format.Number));
        //    Debug.WriteLine("Total Items: {0}", result.TotalItems.ToString(Format.Number));
        //}
        /// <summary>
        /// Populates the list of a pagination result with x number of items as specified by 
        /// value of <paramref name="perpage"/> on the specified <paramref name="page"/>
        /// </summary>
        /// <typeparam name="T">Type of object in the collection.</typeparam>
        /// <param name="enumerable">Collection containing all the items requested/</param>
        /// <param name="page">Page to get items from.</param>
        /// <param name="perpage">Number of items to use in the every pagination request.</param>
        /// <param name="isLastPage">Is <paramref name="page"/> the last page out of all total
        /// number of pages.
        /// </param>
        /// <param name="remaining">The number of items contained in the last page and is less than
        /// <paramref name="perpage"/> value.
        /// </param>
        /// <returns>An array of items of <typeparamref name="T"/> Type in the specified
        /// <paramref name="page"/>
        /// 
        /// The array might contain either x number of items as specified by <paramref name="perpage"/>
        /// value or y if <paramref name="page"/> is the last page & <paramref name="isLastPage"/>
        /// is true and thus the number of items returned the <paramref name="remaining"/> parameter
        /// value.
        /// </returns>
        private static T[] GetCurrentItems<T>(IEnumerable<T> enumerable, int page, int perpage, bool isLastPage, int remaining=0)
        {
            page = (page - 1);

            int start = (int)(page * perpage);
            int last = (isLastPage) ? start + remaining : start + perpage;
            
            if(isLastPage && remaining > 0) {
                return enumerable.Skip(start)
                                 .Take(remaining)
                                 .ToArray();
            }
            else {
                return enumerable.Skip(start)
                                 .Take(perpage)
                                 .ToArray();
            }
        }
        #endregion
    }
}
