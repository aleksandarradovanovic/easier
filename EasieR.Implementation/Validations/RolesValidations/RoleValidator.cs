using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations
{
    public class RoleValidator : AbstractValidator<RolesDto>
    {
        public RoleValidator(EasieRContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty").Must(name => !context.Roles.Any(r => r.Name == name)).WithMessage("Role with this name already exists");
        }
    }
}
