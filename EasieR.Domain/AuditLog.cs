using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int CommandId { get; set; }
        public string CommandName { get; set; }
        public DateTime CommandAt { get; set; }
        public int? UserId { get; set; }
        public string UserIdentity { get; set; }
        public bool IsRequestSuccess { get; set; }
        public string? Comment { get; set; }

    }
}
