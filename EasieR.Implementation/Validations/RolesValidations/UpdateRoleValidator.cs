using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.RolesValidations
{
   public class UpdateRoleValidator : AbstractValidator<RolesDto>
    {
        public UpdateRoleValidator(EasieRContext context)
        {
            RuleFor(x => x.Name).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((role, name) => !context.Roles.Any(x => x.Name == name && x.Id != role.Id))
                .WithMessage("This name is already taken.");
            });
        }
    }
}
