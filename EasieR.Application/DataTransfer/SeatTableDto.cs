using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class SeatTableDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public bool isAvailable { get; set; }
        public PlaceDto PlaceDto { get; set; }
        public ReservationDto ReservationDto { get; set; }

    }
}
