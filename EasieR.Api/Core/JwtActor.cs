using EasieR.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasieR.Api.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id  { get; set; }

        public string Identity { get; set; }

        public IEnumerable<string> AllowedUsecases { get; set; }
}
}
