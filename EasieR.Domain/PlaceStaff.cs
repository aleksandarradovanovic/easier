using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class PlaceStaff : Entity
    {
        public string Position { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
