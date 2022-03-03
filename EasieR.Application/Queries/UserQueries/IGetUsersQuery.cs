using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.UserQueries
{
    public interface IGetUsersQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {
    }
}
