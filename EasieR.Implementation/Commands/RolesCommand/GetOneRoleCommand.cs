using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.RolesQueries;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.RolesCommand
{
    public class GetOneRoleCommand : IGetOneRoleQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetOneRoleCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
        }
        public int Id => 7;

        public string Name => RolesConstants.GetOneRole;

        public RolesDto Execute(int id)
        {
            try
            {
                var role = _easieRContext.Roles.FirstOrDefault(x=>!x.isDeleted && x.Id == id);
                if(role == null)
                {
                    throw new EntityNotFoundException(id, "Role");
                }
                RolesDto rolesDto = _mapper.Map<RolesDto>(role);
                return rolesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
