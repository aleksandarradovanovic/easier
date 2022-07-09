using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Exceptions
{
    public class GeneralErrorException : Exception
    {
        public GeneralErrorException(string message)
    : base(message != null ? message : "General server error")
        {

        }
    }
}
