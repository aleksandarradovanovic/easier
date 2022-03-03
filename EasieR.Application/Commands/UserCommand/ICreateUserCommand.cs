using EasieR.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Commands
{
    public interface ICreateUserCommand : ICommand<UserDto>
    {
    }
}
