using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.RolesQueries
{
    public interface IGetRolesQuery : IQuery<RolesSearch, PagedResponse<RolesDto>>
    {
    }
}
