using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EasieR.DataAccess
{
    public class InitData
    {
        public static List<Actor> CreateActors()
        {
            var actor = new List<Actor>
            {
                 new Actor
                {
                    Id = 1,
                    Name = DataConstants.adminActor
                },
                  new Actor
                {
                    Id = 2,
                    Name = DataConstants.publicActor
                }, new Actor
                {
                    Id = 3,
                    Name = DataConstants.placeActor
                },
                  new Actor
                {
                    Id = 4,
                    Name = DataConstants.publicUnautorizedActor
                }
  
            };
            return actor;
        }
        public static List<Roles> CreateRoles()
        {
            var roles = new List<Roles>
            {
                new Roles
                {
                    Id = 1,
                    Name = DataConstants.CreateUser
                },
                 new Roles
                {
                    Id = 2,
                    Name = DataConstants.GetOneUser
                },
                new Roles
                {
                    Id = 3,
                    Name = DataConstants.SearchUsers
                },
                 new Roles
                 {
                    Id = 4,
                    Name = DataConstants.UpdateUsers
                 },
                 new Roles
                {
                    Id = 5,
                    Name = DataConstants.DeleteUser
                },
                 new Roles
                {
                    Id = 6,
                    Name = DataConstants.CreateRole
                },
                new Roles
                {
                    Id = 7,
                    Name = DataConstants.GetOneRole
                },
                 new Roles
                 {
                    Id = 8,
                    Name = DataConstants.SearchRole
                 },
                 new Roles
                {
                    Id = 9,
                    Name = DataConstants.UpdateRole
                },
                 new Roles
                {
                    Id = 10,
                    Name = DataConstants.DeleteRole
                },
                new Roles
                {
                    Id = 11,
                    Name = DataConstants.CreateLocation
                },
                 new Roles
                 {
                    Id = 12,
                    Name =  DataConstants.GetOneLocation
                 },
                  new Roles
                 {
                    Id = 13,
                    Name =  DataConstants.SearchLocation
                 },
                  new Roles
                 {
                    Id = 14,
                    Name =  DataConstants.UpdateLocation
                 },
                   new Roles
                 {
                    Id = 15,
                    Name = DataConstants.DeleteLocation
                 },
                  new Roles
                {
                    Id = 16,
                    Name =  DataConstants.CreatePlace
                },
                 new Roles
                 {
                    Id = 17,
                    Name =  DataConstants.GetOnePlace

                 },
                  new Roles
                 {
                    Id = 18,
                    Name =  DataConstants.SearchPlace
                 },
                  new Roles
                 {
                    Id = 19,
                    Name =  DataConstants.UpdatePlace
                 },
                    new Roles
                 {
                    Id = 20,
                    Name =  DataConstants.DeletePlace
                 },
                  new Roles
                {
                    Id = 21,
                    Name =  DataConstants.CreateEvent
                },
                 new Roles
                 {
                    Id = 22,
                    Name = DataConstants.GetOneEvent
                 },
                  new Roles
                 {
                    Id = 23,
                    Name = DataConstants.SearchEvent
                 },
                  new Roles
                 {
                    Id = 24,
                    Name = DataConstants.UpdateEvent
                 },
                    new Roles
                 {
                    Id = 25,
                    Name = DataConstants.DeleteEvent
                 },
                    new Roles
                 {
                    Id = 26,
                    Name = DataConstants.CreateReservation
                },
                 new Roles
                 {
                    Id = 27,
                    Name = DataConstants.GetOneReservation
                 },
                  new Roles
                 {
                    Id = 28,
                    Name = DataConstants.SearchReservation
                 },
                  new Roles
                 {
                    Id = 29,
                    Name = DataConstants.UpdateReservation
                 },
                    new Roles
                 {
                    Id = 30,
                    Name = DataConstants.DeleteReservation
                 },
                  new Roles
                 {
                    Id = 31,
                    Name = DataConstants.GetAuditLogs
                  },
                  new Roles
                 {
                    Id = 32,
                    Name = DataConstants.GetPlaceStaff
                 },
                  new Roles
                  {
                    Id = 33,
                    Name = DataConstants.GetSeatTables
                  },
                  new Roles
                 {
                    Id = 34,
                    Name = DataConstants.GetImages
                 }
            };
            return roles;
        }
        public static List<ActorRoles> CreateActorRoles()
        {
            ActorRoles returnActorRoleRole(string role, string actorName)
            {
                return new ActorRoles
                {
                    ActorId = CreateActors().FirstOrDefault(x => x.Name == actorName).Id,
                    RoleId = CreateRoles().FirstOrDefault(x => x.Name == role).Id

                };
            }
            var roles = new List<ActorRoles>
                    {
                        returnActorRoleRole(DataConstants.CreateUser, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreateUser, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.CreateUser, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.CreateUser, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.GetOneUser, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOneUser, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetOneUser, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.SearchUsers, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchUsers, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchUsers, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.UpdateUsers, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdateUsers, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.UpdateUsers, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.DeleteUser, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeleteUser, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.DeleteUser, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.CreateRole, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreateRole, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetOneRole, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOneRole, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.SearchRole, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchRole, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchRole, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.UpdateRole, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdateRole, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.DeleteRole, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeleteRole, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.CreateLocation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreateLocation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetOneLocation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOneLocation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.SearchLocation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchLocation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchLocation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.UpdateLocation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdateLocation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.DeleteLocation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeleteLocation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.CreatePlace, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreatePlace, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetOnePlace, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOnePlace, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetOnePlace, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.GetOnePlace, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.SearchPlace, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchPlace, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchPlace, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.SearchPlace, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.UpdatePlace, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdatePlace, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.DeletePlace, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeletePlace, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.CreateEvent, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreateEvent, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetOneEvent, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOneEvent, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetOneEvent, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.GetOneEvent, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.SearchEvent, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchEvent, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchEvent, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.SearchEvent, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.UpdateEvent, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdateEvent, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.DeleteEvent, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeleteEvent, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.CreateReservation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.CreateReservation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.CreateReservation, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.CreateReservation, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.GetOneReservation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetOneReservation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetOneReservation, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.GetOneReservation, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.SearchReservation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.SearchReservation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.SearchReservation, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.UpdateReservation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.UpdateReservation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.UpdateReservation, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.UpdateReservation, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.DeleteReservation, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.DeleteReservation, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.DeleteReservation, DataConstants.placeActor),
                        returnActorRoleRole(DataConstants.DeleteReservation, DataConstants.publicUnautorizedActor),

                        returnActorRoleRole(DataConstants.GetAuditLogs, DataConstants.adminActor),


                        returnActorRoleRole(DataConstants.GetPlaceStaff, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetPlaceStaff, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetPlaceStaff, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetImages, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetImages, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetImages, DataConstants.placeActor),

                        returnActorRoleRole(DataConstants.GetSeatTables, DataConstants.adminActor),
                        returnActorRoleRole(DataConstants.GetSeatTables, DataConstants.publicActor),
                        returnActorRoleRole(DataConstants.GetSeatTables, DataConstants.placeActor)

                    };
            return roles;
        }

        public static User CreateAdminUser()
        {
            return new User
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin",
                Password = "admin123",
                Email = "admin@root",
                DateOfBirth = new DateTime(),
                ActorId = CreateActors().FirstOrDefault(x => x.Name == DataConstants.adminActor).Id
            };
        }

        }
}
