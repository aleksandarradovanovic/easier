using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands;
using EasieR.Application.Commands.RolesCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.RolesQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCasesExecutor executor;

        public RolesController(IApplicationActor actor, UseCasesExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }


        // GET: api/Roles
        [HttpGet]
        public IActionResult Get([FromQuery] RolesSearch dto, [FromServices] IGetRolesQuery getRolesQuery)
        {
          
            return Ok(executor.ExecuteQuery(getRolesQuery, dto));
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRoleQuery getOneRoleQuery)
        {
            return Ok(executor.ExecuteQuery(getOneRoleQuery, id));
 
        }

        // POST: api/Roles
        [HttpPost]
        public IActionResult Post([FromBody] RolesDto rolesDto, [FromServices] ICreateRoleCommand command)
        {
            executor.ExecuteCommand(command, rolesDto);
            return StatusCode(201, new { message = "Role created." });
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RolesDto rolesDto, [FromServices] IUpdateRoleCommand command)
        {
            rolesDto.Id = id;
            executor.ExecuteCommand(command, rolesDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand deleteRoleCommand)
        {
            executor.ExecuteCommand(deleteRoleCommand, id);
            return NoContent();
        }
    }
}
