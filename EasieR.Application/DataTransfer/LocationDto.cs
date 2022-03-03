using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
