using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class ReservationType : Entity
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Remark { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public ICollection<SeatTableReservationType> SeatTableReservationTypes { get; set; } = new HashSet<SeatTableReservationType>();
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();




    }
}
