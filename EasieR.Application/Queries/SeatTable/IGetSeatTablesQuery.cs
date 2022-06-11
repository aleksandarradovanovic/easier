using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.SeatTable
{
    public interface IGetSeatTablesQuery : IQuery<SeatTableSearch, PagedResponse<SeatTableDto>>
    {
    }
}
