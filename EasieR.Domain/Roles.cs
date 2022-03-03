using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Roles : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; } = new HashSet<UserRoles>();


    }
}
