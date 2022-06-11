using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class ImageSearch : PagedRequest
    {
        public int PlaceId { get; set; }
        public int EventId { get; set; }
    }
}
