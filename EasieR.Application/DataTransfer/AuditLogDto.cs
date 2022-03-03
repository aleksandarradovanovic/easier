using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class AuditLogDto
    {
        public int CommandId { get; set; }
        public string CommandName { get; set; }
        public DateTime CommandAt { get; set; }
        public int UserId { get; set; }
        public string UserIdentity { get; set; }
        public bool IsRequestSuccess { get; set; }
        public string Comment { get; set; }


    }
}
