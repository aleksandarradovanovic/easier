using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasieR.Domain
{
   public class Location : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
