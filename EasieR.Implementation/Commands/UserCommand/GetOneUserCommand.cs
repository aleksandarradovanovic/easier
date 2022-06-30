using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.UserQueries;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.UserCommand
{
    public class GetOneUserCommand : IGetOneUserQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetOneUserCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
            
        }
        public int Id => 2;

        public string Name => RolesConstants.GetOneUser;

        public UserDto Execute(int id)
        {
            try
            {
                var user = _easieRContext.Users.Include(x => x.Actor).ThenInclude(x => x.ActorRoles).ThenInclude(x => x.Roles)
                    .FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if(user == null)
                {
                    throw new EntityNotFoundException(Id, "User");

                }
                UserDto userDto = _mapper.Map<UserDto>(user);
                return userDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
