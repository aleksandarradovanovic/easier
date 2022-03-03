using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
   public class PlaceSearch : PagedRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
    }
}
