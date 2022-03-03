using EasieR.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.UserQueries
{
    public interface IGetOneUserQuery : IQuery<int, UserDto>
    {
    }
}
