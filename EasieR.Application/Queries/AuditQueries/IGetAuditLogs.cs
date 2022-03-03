using EasieR.Application.DataTransfer;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.Queries.AuditQueries
{
    public interface IGetAuditLogs : IQuery<AuditLogSearch, PagedResponse<AuditLogDto>>
    {
    }
}
