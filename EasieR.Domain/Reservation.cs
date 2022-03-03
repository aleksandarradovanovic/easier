using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Reservation : Entity
    {

        public string Type { get; set; }
        public string NameOn { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public int EventId { get; set; }

        public Place Place { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public virtual ICollection<SeatTableReservation> SeatTableReservation { get; set; } = new HashSet<SeatTableReservation>();

    }
}
