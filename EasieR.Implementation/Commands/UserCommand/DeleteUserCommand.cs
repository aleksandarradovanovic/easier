using EasieR.Application.Commands.UserCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.UserCommand
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeleteUserCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 5;

        public string Name => RolesConstants.DeleteUser;

        public void Execute(int id)
        {
            try
            {
                var user = _easieRContext.Users.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (user == null)
                {
                    throw new EntityNotFoundException(id, "User");
                }
                user.isDeleted = true;
                user.DeletedAt = DateTime.Now;
                user.isActive = false;
                user.Status = "DELETED";
                _easieRContext.Users.Update(user);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
