using EasieR.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Validations.LocationValidations
{
    public class CreateLocationValidator : AbstractValidator<LocationDto>
    {
        public CreateLocationValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country cannot be empty");
            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty");
            RuleFor(x => x.StreetAndNumber).NotEmpty().WithMessage("Street and number cannot be empty");
        }
    }
}
