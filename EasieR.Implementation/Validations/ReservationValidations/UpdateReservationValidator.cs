using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Validations.ReservationValidations
{
    public class UpdateReservationValidator : AbstractValidator<ReservationDto>
    {
        public UpdateReservationValidator(EasieRContext context)
        {
            RuleFor(x => x.NameOn).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();

        }
    }
}
