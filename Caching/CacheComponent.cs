using Paginator.Models;
using System;

namespace Caching
{
    /// <summary>
    /// Logical unit for storing data into cache.
    /// </summary>
    public class CacheComponent
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
        public Type Type { get; set; }
        /// <summary>
        /// Original <see cref="Request"/> object used to perform pagination.
        /// </summary>
        public Request Request { get; set; }
        /// <summary>
        /// The object with data generated after pagination
        /// processing that will be returned by caching system.
        /// </summary>
        public object Result { get; set; }
        /// <summary>
        /// The exact date & time that this <see cref="CacheComponent{T}"/> was 
        /// created.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
