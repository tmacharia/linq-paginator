using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paginator.Models;

namespace Paginator.Exceptions
{
    /// <summary>
    /// Error thrown when a pagination <see cref="Request"/> requires contents
    /// from a page that is not within the range of pages that the result has.
    /// </summary>
    public class OutOfRangeException : Exception
    {
        private readonly string _message = string.Empty;
        /// <summary>
        /// Throws an exception when a pagination request requires a <paramref name="pageNumber"/> 
        /// that is not within the range of <paramref name="totalPages"/>
        /// 
        /// </summary>
        /// <param name="pageNumber">Integer value less than or equal to <paramref name="totalPages"/>
        /// to return the contents/items in that section.
        /// </param>
        /// <param name="totalPages">Maximum number of pages as an integer value that houses all
        /// the contents/items in your pagination request.
        /// </param>
        public OutOfRangeException(int pageNumber, int totalPages)
        {
            if(pageNumber < 0)
            {
                _message += "Invalid page number. Page number can only be a positive integer number.";
            }
            else if(pageNumber > totalPages)
            {
                _message += $"Page requested is out of range. Collection results has a maximum of {totalPages} pages to query.\nUse a value that is less than or equal to {totalPages}";
            }
        }
        /// <summary>
        /// Message generated/displayed when an exception of type <see cref="OutOfRangeException"/>
        /// is thrown.
        /// </summary>
        public override string Message => _message;
    }
}
