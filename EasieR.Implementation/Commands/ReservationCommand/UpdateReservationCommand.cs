using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.ReservationValidations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class UpdateReservationCommand : IUpdateReservationCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly UpdateReservationValidator _validator;

        public UpdateReservationCommand(EasieRContext easieRContext, UpdateReservationValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;
        }
        public int Id => 29;

        public string Name => RolesConstants.UpdateReservation;

        public void Execute(ReservationDto reservationDto)
        {
            try
            {
                var reservationsForUpdate = _easieRContext.Reservation.Include(x => x.Event).Include(x => x.User).Include(x => x.Place).ThenInclude(x => x.Location).Include(x => x.SeatTableReservation).ThenInclude(x => x.SeatTable).FirstOrDefault(x => !x.isDeleted && x.Id == reservationDto.Id);
                if (reservationsForUpdate == null)
                {
                    throw new EntityNotFoundException(reservationDto.Id, "Reservation");
                }
                _validator.ValidateAndThrow(reservationDto);
                reservationsForUpdate.Type = reservationDto.Type;
                reservationsForUpdate.NameOn = reservationDto.NameOn;
                reservationsForUpdate.UserId = reservationDto.UserId;
                reservationsForUpdate.Remark = reservationDto.Remark;
                reservationsForUpdate.Status = reservationDto.Status;
                reservationsForUpdate.NumberOfGuests = reservationDto.NumberOfGuests;
                reservationsForUpdate.Price = reservationDto.Price;
                reservationsForUpdate.PlaceId = reservationDto.PlaceId;
                reservationsForUpdate.EventId = reservationDto.EventId;
                if (reservationDto.SeatTableDtos != null && reservationDto.SeatTableDtos.Count > 0)
                {
                    reservationsForUpdate.SeatTableReservation = reservationDto.SeatTableDtos.Select(x => new SeatTableReservation
                    {
                        SeatTableId = x.Id
                    }).ToArray();
                }
                _easieRContext.Reservation.Update(reservationsForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
