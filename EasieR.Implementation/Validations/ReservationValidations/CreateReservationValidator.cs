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
     //       RuleFor(x => x.SeatTableDtos).Must((reservation, seats) => !context.Reservation.AsQueryable().Where(r=>r.ReservationType.Id == reservation.EventId).Any(e=>e.SeatTableReservation.Any(sr=>seats.Any(s=>s.Id == sr.SeatTableId))))
       //          .WithMessage("Seat is already reserverd");
        }
    }
}
