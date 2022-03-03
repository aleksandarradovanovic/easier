using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace EasieR.Application
{
    public class UseCasesExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;
        public UseCasesExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            logger.Log(command, actor);
            if (!actor.AllowedUsecases.Contains(command.Name))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            command.Execute(request);
        }
        public TResult ExecuteQuery<TRequest, TResult>(IQuery<TRequest, TResult> command, TRequest request)
        {
            logger.Log(command, actor);
            if (!actor.AllowedUsecases.Contains(command.Name))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            return command.Execute(request);
        }
    }
}
