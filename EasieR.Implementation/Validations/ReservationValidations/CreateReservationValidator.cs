using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Validations.ReservationValidations
{
    public class CreateReservationValidator : AbstractValidator<ReservationDto>
    {
        public CreateReservationValidator(EasieRContext context)
        {
            RuleFor(x => x.NameOn).NotEmpty();
            RuleFor(x => x.ReservationTypeId).NotEmpty();

        }
    }
}
