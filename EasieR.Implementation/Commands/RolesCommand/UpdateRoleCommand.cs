using EasieR.Application.Commands.RolesCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.RolesValidations;
using FluentValidation;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.RolesCommand
{
    public class UpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly UpdateRoleValidator _validator;
        public UpdateRoleCommand(EasieRContext easieRContext, UpdateRoleValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;

        }
        public int Id => 9;

        public string Name => RolesConstants.UpdateRole;

        public void Execute(RolesDto request)
        {
            try
            {
                var roleForUpdate = _easieRContext.Roles.FirstOrDefault(x => x.Id == request.Id);
                if (roleForUpdate == null)
                {
                    throw new EntityNotFoundException(request.Id, "Role");
                }
                _validator.ValidateAndThrow(request);

                roleForUpdate.Name = request.Name;
                _easieRContext.Roles.Update(roleForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
