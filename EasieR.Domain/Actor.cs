using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class Actor : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ActorRoles> ActorRoles { get; set; } = new HashSet<ActorRoles>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

    }
}
