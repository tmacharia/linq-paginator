namespace Paginator
{
    /// <summary>
    /// Structure of a pagination request to <c>Paginator</c> which describes
    /// how the pagination result should be formatted/packaged.
    /// 
    /// </summary>
    public struct PaginationRequest 
    {
        public PaginationRequest(int page, int perPage)
        {
            Page = page;
            ItemsPerPage = perPage;
        }
        /// <summary>
        /// A specific page number within the range number of total pages. Should always
        /// be less or equal to the total number of pages.
        /// 
        /// Specifying the page number will also return a list with items from that range
        /// region in the original results array.
        /// </summary>
        public int Page { get; set; } 
        /// <summary>
        /// How many items do you want returned in each page. e.g 2,5,10,20...
        /// 
        /// Items per page will define the total number of pages that will be required
        /// to format your data.
        /// </summary>
        public int ItemsPerPage { get; set; }
    }

}