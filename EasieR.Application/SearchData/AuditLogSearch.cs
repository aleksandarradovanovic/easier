using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
   public class AuditLogSearch : PagedRequest
    {
        public string CommandName { get; set; }
        public DateTime CommandAt { get; set; }
        public string UserIdentity { get; set; }
        public bool IsRequestSuccess { get; set; }
    }
}
