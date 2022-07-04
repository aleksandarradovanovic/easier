using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ReservationTypeSeatsDto
    {
        public int SeatTableId { get; set; }
        public SeatTableDto SeatTableDto { get; set; }
    }
}
