using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.ReservationQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class GetReservationsCommand : IGetReservationsQuery
    {
        private readonly EasieRContext _easieRContext;
        public GetReservationsCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 28;

        public string Name => RolesConstants.SearchReservation;

        public PagedResponse<ReservationDto> Execute(ReservationSearch search)
        {
            try
            {
                var reservations = _easieRContext.Reservation.Include(x => x.ReservationType).ThenInclude(x=>x.Event).ThenInclude(x => x.Place).ThenInclude(x => x.Location).Include(x => x.User).Include(x => x.SeatTableReservation).ThenInclude(x => x.SeatTable).AsQueryable().Where(x => !x.isDeleted);
                var skipCount = search.PerPage * (search.Page - 1);
                if (search.Type != null)
                {
                    search.Type = search.Type.ToLower();
                    reservations = reservations.Where(x => x.ReservationType.Name.ToLower().Contains(search.Type));
                }
                if (search.UserId != 0)
                {
                    reservations = reservations.Where(x => x.UserId == search.UserId);
                }
                if (search.NameOn != null)
                {
                    search.NameOn = search.NameOn.ToLower();
                    reservations = reservations.Where(x => x.NameOn.ToLower().Contains(search.NameOn));
                }
                if (search.Status != null)
                {
                    search.Status = search.Status.ToLower();
                    reservations = reservations.Where(x => x.Status.ToLower().Contains(search.Status));
                }
                if (search.PlaceName != null)
                {
                    search.PlaceName = search.PlaceName.ToLower();
                    reservations = reservations.Where(x => x.ReservationType.Event.Place.Name.ToLower().Contains(search.PlaceName));
                }
                if (search.PlaceType != null)
                {
                    search.PlaceType = search.PlaceType.ToLower();
                    reservations = reservations.Where(x => x.ReservationType.Event.Place.Type.ToLower().Contains(search.PlaceType));
                }
                if (search.EventName != null)
                {
                    search.EventName = search.EventName.ToLower();
                    reservations = reservations.Where(x => x.ReservationType.Event.Name.ToLower().Contains(search.EventName));
                }
                if (search.EventId != 0)
                {
                    reservations = reservations.Where(x => x.ReservationType.Event.Id == search.EventId);
                }
                reservations = reservations.OrderByDescending(x => x.CreatedAt);
                var response = new PagedResponse<ReservationDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = reservations.Count(),
                    Items = reservations.Skip(skipCount).Take(search.PerPage).Select(x => new ReservationDto
                    {
                        Id = x.Id,
                        NameOn = x.NameOn,
                        Status = x.Status,
                        NumberOfGuests = x.NumberOfGuests,
                        PlaceName = x.ReservationType.Event.Place.Name,
                        PlaceType = x.ReservationType.Event.Place.Type,
                        CompleteAddress = x.ReservationType.Event.Place.Location.Country + ", " + x.ReservationType.Event.Place.Location.City + ", " + x.ReservationType.Event.Place.Location.StreetAndNumber,
                        Username = x.User.UserName,
                        UserId = x.User.Id,
                        EventName = x.ReservationType.Event.Name,
                        EventDescription = x.ReservationType.Event.Description,
                        EventStartTime = x.ReservationType.Event.StartTime,
                        ReservationTypeDto = new ReservationTypeDto { 
                         Name = x.ReservationType.Name,
                         Price = x.ReservationType.Price,
                         Remark = x.ReservationType.Remark,
                         MaxNumberOfGuests = x.ReservationType.MaxNumberOfGuests
                        },
                        SeatTableDtos = x.SeatTableReservation.Select(y => new SeatTableDto
                        {
                            Number = y.SeatTable.Number
                        }).ToArray()
                    })


                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
