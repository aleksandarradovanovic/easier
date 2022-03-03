using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<string> AllowedUsecases { get; }
    }
}
