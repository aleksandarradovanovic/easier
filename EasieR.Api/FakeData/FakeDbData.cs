using EasieR.Application.Constants;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Api.FakeData
{
    public class FakeDbData
    {
        public List<Roles> CreateRoles()
        {
            var roles = new List<Roles>
            {
                new Roles
                {
                    Name = RolesConstants.CreateUser
                },
                 new Roles
                {
                    Name = RolesConstants.GetOneUser
                },
                new Roles
                {
                    Name = RolesConstants.SearchUsers
                },
                 new Roles
                 {
                    Name = RolesConstants.UpdateUsers
                 },
                 new Roles
                {
                    Name = RolesConstants.DeleteUser
                },
                 new Roles
                {
                    Name = RolesConstants.CreateRole
                },
                new Roles
                {
                    Name = RolesConstants.GetOneRole
                },
                 new Roles
                 {
                    Name = RolesConstants.SearchRole
                 },
                 new Roles
                {
                    Name = RolesConstants.UpdateRole
                },
                 new Roles
                {
                    Name = RolesConstants.DeleteRole
                },
                new Roles
                {
                    Name = RolesConstants.CreateLocation
                },
                 new Roles
                 {
                    Name =  RolesConstants.GetOneLocation
                 },
                  new Roles
                 {
                    Name =  RolesConstants.SearchLocation
                 },
                  new Roles
                 {
                    Name =  RolesConstants.UpdateLocation
                 },
                   new Roles
                 {
                    Name = RolesConstants.DeleteLocation
                 },
                  new Roles
                {
                    Name =  RolesConstants.CreatePlace
                },
                 new Roles
                 {
                    Name =  RolesConstants.GetOnePlace
                 },
                  new Roles
                 {
                    Name =  RolesConstants.SearchPlace
                 },
                  new Roles
                 {
                    Name =  RolesConstants.UpdatePlace
                 },
                    new Roles
                 {
                    Name =  RolesConstants.DeletePlace
                 },
                  new Roles
                {
                    Name =  RolesConstants.CreateEvent
                },
                 new Roles
                 {
                    Name = RolesConstants.GetOneEvent
                 },
                  new Roles
                 {
                    Name = RolesConstants.SearchEvent
                 },
                  new Roles
                 {
                    Name = RolesConstants.UpdateEvent
                 },
                    new Roles
                 {
                    Name = RolesConstants.DeleteEvent
                 },
                    new Roles
                 {
                    Name = RolesConstants.CreateReservation
                },
                 new Roles
                 {
                    Name = RolesConstants.GetOneReservation
                 },
                  new Roles
                 {
                    Name = RolesConstants.SearchReservation
                 },
                  new Roles
                 {
                    Name = RolesConstants.UpdateReservation
                 },
                    new Roles
                 {
                    Name = RolesConstants.DeleteReservation
                 },
                  new Roles
                 {
                    Name = RolesConstants.GetAuditLogs
                 }
            };
            return roles;
        }
        public List<User> CreateUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@root",
                    DateOfBirth = new DateTime(2011, 6, 10),
                    Password = "12345",
                    Status = "CREATED",
                    PhoneNumber = "0634645645"
                },
                  new User
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    UserName = "pera",
                    Email = "pera@gmail.com",
                    DateOfBirth = new DateTime(2011, 6, 10),
                    Password = "12345",
                    Status = "CREATED",
                    PhoneNumber = "0634335645"
                }
            };
            return users;
        }
        public List<Place> CreatePlace()
        {
          var place = new List<Place> {
           new Place
            {
                Name = "Navigator bar",
                Type = "restaurant",
                Description = "Bar with drink and food",
                StartWorkingTime ="08:00",
                EndWorkingTime = "16:00",
                Location = new Location
                {
                    Country = "Serbia",
                    City = "Belgrade",
                    StreetAndNumber = "Bulevar Milutina Milankovica 12",
                    Latitude = (decimal)44.787197,
                    Longitude = (decimal)20.457273
                },
                SeatTables = new List<SeatTable>
                {
                    new SeatTable
                    {
                        Number = "1",
                        Type = "Table"
                    },
                    new SeatTable
                    {
                        Number = "2",
                        Type = "Table"
                    },
                    new SeatTable
                    {
                        Number = "3",
                        Type = "Table"
                    },
                    new SeatTable
                    {
                        Number = "4",
                        Type = "Table"
                    }

                }

             },
             new Place {
                Name = "Kombank dvorana",
                Type = "cinema",
                Description = "Cinema and theatre",
             StartWorkingTime ="08:00",
                EndWorkingTime = "16:00",
                Location = new Location
                {
                    Country = "Serbia",
                    City = "Belgrade",
                    StreetAndNumber = "Terazije 1",
                    Latitude = (decimal)44.787397,
                    Longitude = (decimal)20.433273
                },
                SeatTables = new List<SeatTable>
                {
                    new SeatTable
                    {
                        Number = "1a",
                        Type = "Seat"
                    },
                    new SeatTable
                    {
                        Number = "1b",
                        Type = "Table"
                    },
                    new SeatTable
                    {
                        Number = "1c",
                        Type = "Seat"
                    },
                    new SeatTable
                    {
                        Number = "1d",
                        Type = "Seat"
                    }

                }

             }
           };
            return place;
        }
        public List<Event> CreateEventData()
        {
            var eventData = new List<Event>
            {
            new Event
            {
                Name = "New Year Party",
                Type = "party",
                Description = "New year party night",
                StartTime = new DateTime().AddDays(2),
                EndTime = new DateTime().AddDays(3)
            },
             new Event
            {
                Name = "Party new",
                Type = "party",
                Description = "New party",
                StartTime = new DateTime().AddDays(2),
                EndTime = new DateTime().AddDays(3)
            },
            new Event
            {
                Name = "Premiere of movie",
                Type = "movie",
                Description = "Premiere of movie",
                StartTime = new DateTime().AddDays(2),
                EndTime = new DateTime().AddDays(3)
            },
                new Event
            {
                Name = "Fest",
                Type = "movie",
                Description = "Event with a lot of movies",
                StartTime = new DateTime().AddDays(2),
                EndTime = new DateTime().AddDays(3)
            }
        };
            return eventData;
        }
        public List<Reservation> CreateReservationData()
        {
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Type = "Card",
                    NameOn = "Pera",
                    Remark = "Some remark",
                    Status = "CREATED",
                    NumberOfGuests = 2,
                    Price = 100
                }
            };
            return reservations;
        }
    }

}
