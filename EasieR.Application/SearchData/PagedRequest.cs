using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public abstract class PagedRequest
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;

    }
}
