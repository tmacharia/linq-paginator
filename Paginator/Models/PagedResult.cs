using System;
using System.Collections.Generic;

namespace Paginator.Models
{
    public struct PagedResult<T>
    {
        public int page { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public int totalpages
        {
            get
            {
                try
                {
                    int index = 0;
                    index = total / perpage;

                    if ((total % perpage) > 0)
                        index++;

                    return index;
                }
                catch (Exception) { return 0; }
            }
        }
        public ICollection<T> items { get; set; }
    }
}
