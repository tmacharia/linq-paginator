using System.Collections.Generic;

namespace Paginator
{
    /// <summary>
    /// Packages the result of a request showing information
    /// about the pagination request made including:
    /// 
    /// <list type="bullet">
    ///     <item>Current Page Number</item>
    ///     <item>Number of items returned in every page</item>
    ///     <item>Total number of pages holding all the items in the list</item>
    ///     <item>Total number of items in the data source matching your <c>Request</c></item>
    ///     <item>List array contaning (x) number</item>
    /// </list>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T> 
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PagedResult()
        {
            Items = new List<T>();
        }
        /// <summary>
        /// Current page in pagination
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Total number of items in every page as per
        /// pagination request. Defaults to 10.
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Number of pages used to paginate collection with
        /// each page containing (x) items per page
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Number of items matching your pagination request
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Collection containing items in the current page.
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Calculates &amp; returns the hashcode of the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + Page.GetHashCode();
                hash = hash * 23 + ItemsPerPage.GetHashCode();
                hash = hash * 23 + TotalPages.GetHashCode();
                hash = hash * 23 + TotalItems.GetHashCode();
                hash = hash * 23 + Items.GetHashCode();
                return hash;
            }
        }
    }
}