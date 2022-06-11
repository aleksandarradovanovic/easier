using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<PlaceStaff> PlaceStaffs { get; set; } = new HashSet<PlaceStaff>();
        public virtual ICollection<UserRoles> UserRoles { get; set; } = new HashSet<UserRoles>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

    }
}
