using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class EventSearch : PagedRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; } = null;
        public string PlaceName { get; set; }
        public string PlaceType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
