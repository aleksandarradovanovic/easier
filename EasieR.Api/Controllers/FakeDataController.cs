using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Api.FakeData;
using EasieR.DataAccess;
using EasieR.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataController : ControllerBase
    {
        private readonly EasieRContext easieRContext;

        public FakeDataController(EasieRContext easieRContext)
        {
            this.easieRContext = easieRContext;

        }

        // POST: api/FakeData
        [HttpPost]
        public IActionResult Post()
        {
            FakeDbData fakeDbData = new FakeDbData();
            var roles = fakeDbData.CreateRoles();
            easieRContext.Roles.AddRange(roles);

            var users = fakeDbData.CreateUsers();

            var userRoles = roles.Select(x => new UserRoles
            {
                Roles = x
            });
            var userRoles2 = roles.Where(y => y.Id < 20).Select(x => new UserRoles
            {
                Roles = x
            });

            easieRContext.Users.AddRange(users);

            var places = fakeDbData.CreatePlace();
            easieRContext.Place.AddRange(places);

            var events = fakeDbData.CreateEventData();
            events.ForEach(x => x.Place = places.First());
            easieRContext.Event.AddRange(events);

            var reservations = fakeDbData.CreateReservationData();
            reservations.ForEach(x => x.Event = events.First());
            reservations.ForEach(x => x.Place = events.First().Place);
            reservations.ForEach(x => x.User = users.First());
            reservations.ForEach(x => x.SeatTableReservation = x.Event.Place.SeatTables.Select( y =>
            new SeatTableReservation
            {
                SeatTable = y
            }).ToArray());
            easieRContext.Reservation.AddRange(reservations);

            easieRContext.SaveChanges();
            return Ok();
        }

    }
}
