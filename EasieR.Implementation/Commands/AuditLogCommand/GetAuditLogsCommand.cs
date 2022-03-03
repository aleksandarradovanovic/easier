using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.AuditQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.AuditLogCommand
{
    public class GetAuditLogsCommand : IGetAuditLogs
    {
        private readonly EasieRContext _easieRContext;
        public GetAuditLogsCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 31;

        public string Name => RolesConstants.GetAuditLogs;

        public PagedResponse<AuditLogDto> Execute(AuditLogSearch search)
        {
            try
            {
                var logs = _easieRContext.AuditLog.AsQueryable();
                if (search.CommandName != null)
                {
                    search.CommandName = search.CommandName.ToLower();
                    logs = logs.Where(x => x.CommandName.ToLower().Contains(search.CommandName));
                }
                if (search.CommandAt != null)
                {
                    search.CommandAt = search.CommandAt;
                    logs = logs.Where(x => x.CommandAt > search.CommandAt);
                }
                if (search.UserIdentity != null)
                {
                    search.UserIdentity = search.UserIdentity.ToLower();
                    logs = logs.Where(x => x.UserIdentity.ToLower().Contains(search.UserIdentity));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<AuditLogDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = logs.Count(),
                    Items = logs.Skip(skipCount).Take(search.PerPage).Select(x => new AuditLogDto
                    {
                        CommandId = x.CommandId,
                        CommandName = x.CommandName,
                        UserId = (int)x.UserId,
                        UserIdentity = x.UserIdentity,
                        IsRequestSuccess = x.IsRequestSuccess,
                        Comment = x.Comment

                    })
                };
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
