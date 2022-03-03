using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class ReservationSearch : PagedRequest
    {
        public string Type { get; set; }
        public string NameOn { get; set; }
        public string Status { get; set; }
        public string PlaceName { get; set; }
        public string PlaceType { get; set; }
        public string EventName { get; set; }
    }
}
