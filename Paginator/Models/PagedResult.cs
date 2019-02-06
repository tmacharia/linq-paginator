using System.Collections.Generic;

namespace Paginator.Models
{
    public struct PagedResult<T>
    {
        public int page { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public ICollection<T> items { get; set; }
    }
}
