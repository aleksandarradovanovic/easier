using EasieR.Application;
using EasieR.DataAccess;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands
{
    public class LoggerCommand : IUseCaseLogger
    {
        private readonly EasieRContext _easieRContext;
        public LoggerCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public void Log(IUseCase useCase, IApplicationActor actor)
        {
            var log = new AuditLog
            {
                CommandId = useCase.Id,
                CommandName = useCase.Name,
                CommandAt = DateTime.Now,
                UserId = actor.Id,
                UserIdentity = actor.Identity,
                IsRequestSuccess = true

            };
            Console.WriteLine(actor.Identity + ": Is trying to execute" + useCase.Name);
            if (!actor.AllowedUsecases.Contains(useCase.Name))
            {
                log.IsRequestSuccess = false;
                log.Comment = "Unautorized attempt, user is not autentificated";
            }
            _easieRContext.AuditLog.Add(log);
            _easieRContext.SaveChanges();
        }
    }
}
