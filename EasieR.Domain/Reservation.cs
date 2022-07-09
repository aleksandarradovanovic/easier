using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Reservation : Entity
    {
        public string NameOn { get; set; }
        public string Status { get; set; }
        public int NumberOfGuests { get; set; }
        public int UserId { get; set; }
        public int ReservationTypeId { get; set; }
        public int ReservationSequenceId { get; set; }
        public ReservationSequence ReservationSequence { get; set; }

        public User User { get; set; }
        public ReservationType ReservationType { get; set; }
        public virtual ICollection<SeatTableReservation> SeatTableReservation { get; set; } = new HashSet<SeatTableReservation>();

    }
}
