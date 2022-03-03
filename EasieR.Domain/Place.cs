using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Place : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartWorkingTime { get; set; }
        public DateTime EndWorkingTime { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public virtual ICollection<SeatTable> SeatTables { get; set; } = new HashSet<SeatTable>();
        public virtual ICollection<User> Staff { get; set; } = new HashSet<User>();
        public virtual ICollection<Images> Images { get; set; } = new HashSet<Images>();


    }
}
