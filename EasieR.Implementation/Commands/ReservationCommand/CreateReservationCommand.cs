using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.ReservationValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class CreateReservationCommand : ICreateReservationCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly CreateReservationValidator _validator;
        public CreateReservationCommand(EasieRContext easieRContext, CreateReservationValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;

        }
        public int Id => 26;

        public string Name => RolesConstants.CreateReservation;

        public void Execute(ReservationDto reservationDto)
        {
            {
                try
                {
                    _validator.ValidateAndThrow(reservationDto);
                    var reservation = new Reservation
                    {
                        Type = reservationDto.Type,
                        NameOn = reservationDto.NameOn,
                        UserId = reservationDto.UserId,
                        Remark = reservationDto.Remark,
                        Status = reservationDto.Status,
                        NumberOfGuests = reservationDto.NumberOfGuests,
                        Price = reservationDto.Price,
                        PlaceId = reservationDto.PlaceId,
                        EventId = reservationDto.EventId
                    };
                    if (reservationDto.SeatTableDtos != null && reservationDto.SeatTableDtos.Count > 0)
                    {
                        reservation.SeatTableReservation = reservationDto.SeatTableDtos.Select(x => new SeatTableReservation
                        {
                            SeatTableId = x.Id
                        }).ToArray();
                    }
                    _easieRContext.Add(reservation);
                    _easieRContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
