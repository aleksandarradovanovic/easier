using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class LoginResponse : ResultDto
    {
        public string jwt { get; set; }
    }
}
