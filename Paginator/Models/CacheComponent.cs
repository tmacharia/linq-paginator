using System;
using System.Collections.Generic;
using System.Text;

namespace Paginator.Models
{
    /// <summary>
    /// Logical unit for storing data into cache.
    /// </summary>
    public class CacheComponent<T>
        where T : class
    {
        // Constructor
        public CacheComponent()
        {
            this.Timestamp = DateTime.Now;
        }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Full namespace & type for the original collection used
        /// during pagination.
        /// </summary>
        public string CollectionType { get; set; }
        /// <summary>
        /// Original <see cref="Request"/> object used to perform pagination.
        /// </summary>
        public Request Request { get; set; }
        /// <summary>
        /// The <see cref="Result{T}"/> object with data generated after pagination
        /// processing that will be returned by caching system.
        /// </summary>
        public Result<T> Result { get; set; }
        /// <summary>
        /// The exact date & time that this <see cref="CacheComponent{T}"/> was 
        /// created.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
