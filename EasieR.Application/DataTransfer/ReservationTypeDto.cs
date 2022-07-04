using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ReservationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Remark { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public ICollection<ReservationTypeSeatsDto> AvailableSeatTablesDto { get; set; } = new HashSet<ReservationTypeSeatsDto>();

    }
}
