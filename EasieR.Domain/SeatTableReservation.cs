using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class SeatTableReservation
    {
        public int SeatTableId { get; set; }
        public int ReservationId { get; set; }

        public SeatTable SeatTable { get; set ;}
        public Reservation Reservation { get; set; }


    }
}
