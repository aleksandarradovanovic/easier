using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class SeatTableReservationType
    {
        public int SeatTableId { get; set; }
        public int ReservationTypeId { get; set; }

        public SeatTable SeatTable { get; set; }
        public ReservationType ReservationType { get; set; }
    }
}
