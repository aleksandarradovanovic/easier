using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Event : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PlaceId { get; set; }
        
        public Place Place { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<Images> EventImages { get; set; } = new HashSet<Images>();

    }
}
