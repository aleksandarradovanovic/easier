using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ReservationDtos
    {
        public virtual ICollection<ReservationDto> Reservations { get; set; }

    }
}
