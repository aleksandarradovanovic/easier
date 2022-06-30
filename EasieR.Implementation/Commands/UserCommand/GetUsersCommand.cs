using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.UserQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.UserCommand
{
    public class GetUsersCommand : IGetUsersQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetUsersCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
        }
        public int Id => 3;

        public string Name => RolesConstants.SearchUsers;

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            try
            {
                var users = _easieRContext.Users.Include(x => x.Actor).ThenInclude(x => x.ActorRoles).ThenInclude(x => x.Roles).AsQueryable().Where(x => !x.isDeleted);
                if (search.FirstName != null)
                {
                    search.FirstName = search.FirstName.ToLower();
                    users = users.Where(x => x.FirstName.ToLower().Contains(search.FirstName));
                }
                if (search.LastName != null)
                {
                    search.LastName = search.LastName.ToLower();
                    users = users.Where(x => x.LastName.ToLower().Contains(search.LastName));
                }
                if (search.UserName != null)
                {
                    search.UserName = search.UserName.ToLower();
                    users = users.Where(x => x.UserName.ToLower().Contains(search.UserName));
                }
                if (search.Email != null)
                {
                    search.Email = search.Email.ToLower();
                    users = users.Where(x => x.Email.ToLower().Contains(search.Email));
                }
                if (search.Status != null)
                {
                    search.Status = search.Status.ToLower();
                    users = users.Where(x => x.Status.ToLower().Contains(search.Status));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<UserDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = users.Count(),
                    Items = users.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<UserDto>(x))
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
