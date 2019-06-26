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
    public struct PagedResult<T> 
    {
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
        /// Number of pages used to paginate our <see cref="List"/> with
        /// each page containing (x) <see cref="ItemsPerPage"/>
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Number of items matching your pagination request
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Array containing items in the current page 
        /// </summary>
        public T[] List { get; set; }
    }
}