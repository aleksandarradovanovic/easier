using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.EventValidations
{
    public class CreateEventValidator : AbstractValidator<EventDto>
    {
        public CreateEventValidator(EasieRContext context)
        {
            RuleFor(x => x.Name).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((e, name) => !context.Place.Any(x => x.Name == name))
                .WithMessage("This name is already taken.");
            });

            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.PlaceId).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();

        }
    }
}
