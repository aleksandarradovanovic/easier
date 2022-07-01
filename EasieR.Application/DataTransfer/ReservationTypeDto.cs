using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ReservationTypeDto
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Remark { get; set; }
        public int MaxNumberOfGuests { get; set; }
    }
}
