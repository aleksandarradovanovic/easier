using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class ActorRoles
    {
        public int ActorId { get; set; }
        public int RoleId { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
