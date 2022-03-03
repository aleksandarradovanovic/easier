using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Implementation.Validations.LocationValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.PlaceValidations
{
    public class CreatePlaceValidator : AbstractValidator<PlaceDto>
    {
        public CreatePlaceValidator(EasieRContext context)
        {
            RuleFor(x => x.Name).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((place, name) => !context.Place.Any(x => x.Name == name))
                .WithMessage("This name is already taken.");
            });
            RuleFor(x => x.LocationDto).SetValidator(new CreateLocationValidator());

            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.StartWorkingTime).NotEmpty();
            RuleFor(x => x.EndWorkingTime).NotEmpty();

        }
    }
}
