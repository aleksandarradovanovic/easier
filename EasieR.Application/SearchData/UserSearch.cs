using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.SearchData
{
    public class UserSearch : PagedRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

    }
}
