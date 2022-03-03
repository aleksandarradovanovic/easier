using EasieR.Application.Commands.RolesCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.RolesCommand
{
    public class DeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeleteRoleCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 10;

        public string Name => RolesConstants.DeleteRole;

        public void Execute(int id)
        {
            try
            {
                var role = _easieRContext.Roles.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (role == null)
                {
                    throw new EntityNotFoundException(id, "Role");
                }
                role.isDeleted = true;
                role.DeletedAt = DateTime.Now;
                role.isActive = false;
                _easieRContext.Roles.Update(role);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
