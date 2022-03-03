using AutoMapper;
using EasieR.Application.Commands;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations;
using FluentValidation;
using System;

namespace EasieR.Implementation.Commands
{
    public class CreateRoleCommand : ICreateRoleCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly RoleValidator _validator;
        private readonly IMapper _mapper;
        public CreateRoleCommand(EasieRContext easieRContext, RoleValidator validator, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _validator = validator;
            _mapper = mapper;

        }
        public int Id => 6;

        public string Name => RolesConstants.CreateRole;
        public void Execute(RolesDto rolesDto)
        {
            try
            {
                _validator.ValidateAndThrow(rolesDto);
                Roles role = _mapper.Map<Roles>(rolesDto);
                _easieRContext.Roles.Add(role);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
