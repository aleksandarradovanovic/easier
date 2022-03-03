using EasieR.Application.Commands.UserCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.UserValidations;
using FluentValidation;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.UserCommand
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly UpdateUserValidator _validator;
        public UpdateUserCommand(EasieRContext easieRContext, UpdateUserValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;

        }
        public int Id => 4;

        public string Name => RolesConstants.UpdateUsers;

        public void Execute(UserDto userDto)
        {
            try
            {
                var userForUpdate = _easieRContext.Users.FirstOrDefault(x => x.Id == userDto.Id);
                if (userForUpdate == null)
                {
                    throw new EntityNotFoundException(userDto.Id, "User");
                }
                _validator.ValidateAndThrow(userDto);
                userForUpdate.FirstName = userDto.FirstName;
                userForUpdate.LastName = userDto.LastName;
                userForUpdate.UserName = userDto.UserName;
                userForUpdate.DateOfBirth = userDto.DateOfBirth;
                userForUpdate.Email = userDto.Email;
                userForUpdate.Status = "UPDATED";
                userForUpdate.PhoneNumber = userDto.PhoneNumber;
                _easieRContext.Users.Update(userForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
