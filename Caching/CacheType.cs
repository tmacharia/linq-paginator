namespace Caching
{
    /// <summary>
    /// Storage media to use for caching.
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// Uses the machine's Random Access Memory to store cache components.
        /// This type of caching mechanism is very fast and efficient for frequently
        /// accessed data.
        /// 
        /// </summary>
        /// <remarks>
        /// Has a limitation on the size of data that can be cached due to small
        /// storage space in RAM.
        /// </remarks>
        Memory,
        /// <summary>
        /// Uses the machine's HDD or SSD to store cache components. This type
        /// of caching mechanism runs quickly but a bit slower as compared to
        /// <see cref="Memory"/> but very efficient with huge amounts of data.
        /// </summary>
        /// <remarks>
        /// Not quite limited in terms of storage space but dependant on free disk
        /// space on the machine.
        /// </remarks>
        Disk
    }
}
