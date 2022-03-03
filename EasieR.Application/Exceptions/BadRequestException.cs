using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Exceptions
{
   public class BadRequestException : Exception
    {
        public BadRequestException()
          : base("One of sent data is not correct")
        {

        }
    }
}
