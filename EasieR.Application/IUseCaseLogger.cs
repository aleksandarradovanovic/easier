using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor actor);
    }
}
