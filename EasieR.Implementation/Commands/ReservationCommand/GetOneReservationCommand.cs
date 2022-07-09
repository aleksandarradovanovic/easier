using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.ReservationQueries;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class GetOneReservationCommand : IGetOneReservationQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;

        public GetOneReservationCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 27;

        public string Name => RolesConstants.GetOneReservation;

        public ReservationDto Execute(int id)
        {
            try
            {
                var reservations = _easieRContext.Reservation.Include(x => x.ReservationType).ThenInclude(x=>x.Event).ThenInclude(x => x.Place).ThenInclude(x => x.Location).Include(x => x.User).Include(x=>x.SeatTableReservation).ThenInclude(x=>x.SeatTable).Include(x=>x.ReservationSequence).FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (reservations == null)
                {
                    throw new EntityNotFoundException(id, "Reservation");
                }
                ReservationDto reservationDto = _mapper.Map<ReservationDto>(reservations);
                return reservationDto;
    }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
