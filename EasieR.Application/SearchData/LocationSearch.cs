using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class LocationSearch : PagedRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
    }
}
