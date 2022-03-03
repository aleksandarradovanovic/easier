using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.UserValidations
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(EasieRContext context)
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty").DependentRules(() =>
            {
                RuleFor(x => x.UserName).Must((user, name) => !context.Users.Any(x => x.UserName == name && x.Id != user.Id))
                .WithMessage("This username is already taken.");
            });

            RuleFor(x => x.Email).NotEmpty().WithMessage("Enail cannot be empty").DependentRules(() =>
            {
                RuleFor(x => x.Email).Must((user, email) => !context.Users.Any(x => x.Email == email && x.Id != user.Id))
                .WithMessage("This email is already taken.");
            });
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth cannot be empty");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone cannot be empty");

        }
    }
}
