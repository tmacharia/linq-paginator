using Paginator.Exceptions;
using Paginator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Paginator.Formatters;

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
        // Private Variables
        private static int _startPage = 0;
        private const int _items_per_page = 10;

        #region IEnumerable Extensions
        public static Result<T> ToPaged<T>(this IEnumerable<T> enumerable, int page, int itemsPerPage)
            where T : class
        {
            Validate(enumerable, page, itemsPerPage);

            return Process(enumerable, null, page, itemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IEnumerable<T> enumerable,Func<T,bool> predicate, int page, int itemsPerPage)
            where T : class
        {
            Validate(enumerable, page, itemsPerPage);

            return Process(enumerable, predicate, page, itemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IEnumerable<T> enumerable, Request request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, null, request.Page, request.ItemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, Request request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, predicate, request.Page, request.ItemsPerPage);
        }
        #endregion

        #region IQueryable Extensions
        public static Result<T> ToPaged<T>(this IQueryable<T> queryable,int page,int itemsPerPage)
            where T : class
        {
            Validate(queryable, page, itemsPerPage);

            return Process(queryable, null, page, itemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IQueryable<T> queryable, Func<T, bool> predicate, int page, int itemsPerPage)
                where T : class
        {
            Validate(queryable, page, itemsPerPage);

            return Process(queryable, predicate, page, itemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IQueryable<T> enumerable, Request request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, null, request.Page, request.ItemsPerPage);
        }
        public static Result<T> ToPaged<T>(this IQueryable<T> enumerable, Func<T, bool> predicate, Request request)
            where T : class
        {
            request = Validate(enumerable, request);

            return Process(enumerable, predicate, request.Page, request.ItemsPerPage);
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
        /// A pagination <see cref="Result{T}"/> with the expected results.
        /// </returns>
        /// <exception cref="OutOfRangeException">Thrown when the requested page number
        /// is greater than the total number of pages.
        /// </exception>
        private static Result<T> Process<T>(IEnumerable<T> enumerable, Func<T, bool> predicate, int page, int itemsPerPage)
            where T : class
        {
            IEnumerable<T> elements = Enumerable.Empty<T>();


            if (predicate == null)
                elements = enumerable;
            else
                elements = enumerable.Where(predicate);

            int total = elements.Count();

            Result<T> result = new Result<T>
            {
                ItemsPerPage = itemsPerPage,
                TotalItems = total,
                Page = page,
                TotalPages = TotalPages(total, itemsPerPage),
            };

            // Checks correctness of page requested and continues to put the items from
            // that page in the result object list.
            if (total == 0)
            {
                result.List = new List<T>();
            }
            else if (result.Page > result.TotalPages)
                throw new OutOfRangeException(result.Page, result.TotalPages);
            else if (result.Page == result.TotalPages)
                result.List = GetCurrentItems(elements, page, itemsPerPage, true, LastPageCount(total, itemsPerPage));
            else
                result.List = GetCurrentItems(elements, page, itemsPerPage, false);

            // Print out pagination results to console/logger asynchronously
            Task.Run(() => Log(result))
                .Wait();

            return result;
        }
        #endregion

        #region Private Section
        /// <summary>
        /// Checks for errors in parameters/arguments used in a pagination request and throws 
        /// relevant <see cref="Exceptions"/> to stop further processing. If the request object 
        /// provided is null, a request of type <see cref="Request"/> is created with default
        /// values: 
        /// 
        /// </summary>
        /// <example>
        ///     Page : 1,
        ///     ItemsPerPage: 10
        /// </example>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to validate</param>
        /// <param name="request"><see cref="Request"/> object defining pagination rules.</param>
        /// <returns>A validated <see cref="Request"/> object.
        /// </returns>
        /// <exception cref="NullCollectionException">Throws when <paramref name="enumerable"/>
        /// provided is null.
        /// </exception>
        /// <exception cref="InvalidArgumentException">Throws when either parameters in <paramref name="request"/>
        /// object are wrong or negative numbers.
        /// </exception>
        private static Request Validate<T>(IEnumerable<T> enumerable, Request request)
        {
            if (enumerable == null)
                throw new NullCollectionException("enumerable");

            if (request == null)
            {
                request = new Request()
                {
                    Page = _startPage + 1,
                    ItemsPerPage = _items_per_page
                };
            }
            else
            {
                if (request.Page < 0 || request.ItemsPerPage < 0)
                    throw new InvalidArgumentException("Request.Page", "Request.ItemsPerPage");
            }

            return request;
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

            return;
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
        private static int LastPageCount(int total,int perpage)
        {
            return (total % perpage);
        }
        /// <summary>
        /// Logs the results of a pagination request to the console or any logger
        /// attached.
        /// </summary>
        /// <typeparam name="T">Type of object that the result contains.</typeparam>
        /// <param name="result">An object of Type <see cref="Result{T}"/> that contains
        /// all the pagination information:
        /// 
        /// <list type="bullet">
        ///     <listheader>All properties in <typeparamref name="T"/></listheader>
        ///     <item><see cref="Result{T}.Page"/> -> CurrentPage/Requested page</item>
        ///     <item><see cref="Result{T}.TotalPages"/> -> All pages with all the items.</item>
        ///     <item><see cref="Result{T}.ItemsPerPage"/> -> Number of items in every page.</item>
        ///     <item><see cref="Result{T}.List"/> -> List with items in page x.</item>
        ///     <item><see cref="Result{T}.TotalItems"/> -> Total number of items paged.</item>
        /// </list>
        /// </param>
        private static void Log<T>(Result<T> result)
            where T : class
        {
            Console.WriteLine("\n========\nResult object:\n=========\n");
            Console.WriteLine("Current Page: {0}", result.Page.ToString(Format.Number));
            Console.WriteLine("Total Pages: {0}", result.TotalPages.ToString(Format.Number));
            Console.WriteLine("Items per page: {0}", result.ItemsPerPage.ToString(Format.Number));
            Console.WriteLine("Total items in current array: {0}", result.List.Count.ToString(Format.Number));
            Console.WriteLine("Total Items: {0}", result.TotalItems.ToString(Format.Number));
        }
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

            Console.WriteLine("Starting point: {0}\n" +
                              "Ending point: {1}\n" +
                              "Remainder items: {2}\n"
                                               ,start.ToString(Format.Number)
                                               ,last.ToString(Format.Number)
                                               ,remaining.ToString(Format.Number));

            if(isLastPage && remaining > 0)
            {
                return enumerable.Skip(start)
                                 .Take(remaining)
                                 .ToArray();
            }
            else
            {
                return enumerable.Skip(start)
                                 .Take(perpage)
                                 .ToArray();
            }
        }
        #endregion
    }
}
