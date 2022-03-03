using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.EventQueries
{
    public interface IGetEventsQuery : IQuery<EventSearch, PagedResponse<EventDto>>
    {
    }
}
