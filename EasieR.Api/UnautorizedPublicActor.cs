using EasieR.Application;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasieR.Api
{
    public class UnautorizedPublicActor : IApplicationActor
    {
        private readonly EasieRContext _easieRContext;

        public UnautorizedPublicActor()
        {
        }

        public UnautorizedPublicActor(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        
        public int Id => new Random().Next();

        public string Identity => "anonymous";

        public IEnumerable<string> AllowedUsecases => new string[] { 
        DataConstants.CreateUser,
        DataConstants.SearchEvent,
        DataConstants.GetOneEvent,
        DataConstants.CreateReservation
        };
    }
}
