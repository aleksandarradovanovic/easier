using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Queries.AuditQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly UseCasesExecutor executor;
        private readonly IApplicationActor actor;


        public AuditController(UseCasesExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Audit
        [HttpGet]
        public IActionResult Get([FromBody] AuditLogSearch search, [FromServices] IGetAuditLogs query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

    }
}
