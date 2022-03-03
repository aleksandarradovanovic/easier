using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
   public class UserRoles 
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Roles Roles { get; set; }

    }
}
