using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.ReservationQueries
{
   public interface IGetReservationsQuery : IQuery<ReservationSearch, PagedResponse<ReservationDto>>
    {
    }
}
