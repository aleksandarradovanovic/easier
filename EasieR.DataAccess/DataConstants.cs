using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess
{
   public class DataConstants
    {

            public const string CreateUser = "CREATE_USER";
            public const string GetOneUser = "GET_ONE_USER";
            public const string SearchUsers = "SEARCH_USER";
            public const string UpdateUsers = "UPDATE_USER";
            public const string DeleteUser = "DELETE_USER";

            public const string CreateRole = "CREATE_ROLE";
            public const string GetOneRole = "GET_ONE_ROLE";
            public const string SearchRole = "SEARCH_ROLE";
            public const string UpdateRole = "UPDATE_ROLE";
            public const string DeleteRole = "DELETE_ROLE";

            public const string CreateLocation = "CREATE_LOCATION";
            public const string GetOneLocation = "GET_ONE_LOCATION";
            public const string SearchLocation = "SEARCH_LOCATION";
            public const string UpdateLocation = "UPDATE_LOCATION";
            public const string DeleteLocation = "DELETE_LOCATION";

            public const string CreatePlace = "CREATE_PLACE";
            public const string GetOnePlace = "GET_ONE_PLACE";
            public const string SearchPlace = "SEARCH_PLACE";
            public const string UpdatePlace = "UPDATE_PLACE";
            public const string DeletePlace = "DELETE_PLACE";
            public const string GetPlaceStaff = "GET_PLACE_STAFF";


            public const string CreateEvent = "CREATE_EVENT";
            public const string GetOneEvent = "GET_ONE_EVENT";
            public const string SearchEvent = "SEARCH_EVENT";
            public const string UpdateEvent = "UPDATE_EVENT";
            public const string DeleteEvent = "DELETE_EVENT";

            public const string CreateReservation = "CREATE_RESERVATION";
            public const string GetOneReservation = "GET_ONE_RESERVATION";
            public const string SearchReservation = "SEARCH_RESERVATION";
            public const string UpdateReservation = "UPDATE_RESERVATION";
            public const string DeleteReservation = "DELETE_RESERVATION";

            public const string GetAuditLogs = "GET_AUDIT_LOGS";

            public const string GetSeatTables = "GET_SEAT_TABLES";

            public const string GetImages = "GET_IMAGES";

        //actor data
            public const string adminActor = "ADMIN";
            public const string publicActor = "PUBLIC";
            public const string publicUnautorizedActor = "PUBLIC_UNAUTORIZED";
            public const string placeActor = "PLACE";

    }
}
