using EasieR.Application;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Application.Exceptions;
using EasieR.Application.Queries.RolesQueries;
using EasieR.Application.SearchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EasieR.Application.Constants;

namespace EasieR.Implementation.Commands
{
    public class GetRolesQuery : IGetRolesQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetRolesQuery(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => RolesConstants.SearchRole;

        public PagedResponse<RolesDto> Execute(RolesSearch search)
        {
            try
            {
                var role = _easieRContext.Roles.AsQueryable().Where(x=>!x.isDeleted);

                if (search.Name != null)
                {
                    search.Name = search.Name.ToLower();
                    role = role.Where(x => x.Name.ToLower().Contains(search.Name));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<RolesDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = role.Count(),
                    Items = role.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<RolesDto>(x))
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
