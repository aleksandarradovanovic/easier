using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
   public class PagedResponse<T> where T : class, new()
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }

    }
}
