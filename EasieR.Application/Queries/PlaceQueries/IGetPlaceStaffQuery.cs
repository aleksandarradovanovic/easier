using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.PlaceQueries
{
    public interface IGetPlaceStaffQuery : IQuery<PlaceStaffSearch, PagedResponse<PlaceStaffDto>>
    {
    }
}
