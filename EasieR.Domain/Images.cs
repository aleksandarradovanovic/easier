using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Images : Entity
    {
        public string Image { get; set; }
        public int PlaceId { get; set; }
        public int? EventId { get; set; }

        public Place Place { get; set; }
        public Event Event { get; set; }
    }
}
