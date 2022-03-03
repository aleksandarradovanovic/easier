using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class RolesSearch : PagedRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; } 
    }
}
