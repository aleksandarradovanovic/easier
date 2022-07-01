using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.UserValidations
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(EasieRContext context)
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty").Must(name => !context.Users.Any(r => r.UserName == name)).WithMessage("User with this username already exists");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty").Must(name => !context.Users.Any(r => r.Email == name)).WithMessage("Email already registered");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Passowrd cannot be empty");
            RuleFor(x => x.PasswordRepeat).NotEmpty().WithMessage("Passowrd repeat cannot be empty").Must((user, pass) => pass == user.Password).WithMessage("Passowrd and repeated passowrd are not the same");
        }
    }
}
