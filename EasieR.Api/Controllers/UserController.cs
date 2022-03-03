using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands;
using EasieR.Application.Commands.UserCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.UserQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCasesExecutor executor;

        public UserController(UseCasesExecutor executor)
        {
            this.executor = executor;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto, [FromServices] ICreateUserCommand command)
        {
           executor.ExecuteCommand(command, userDto);
            return StatusCode(201, new { message = "User created."});
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto userDto, [FromServices] IUpdateUserCommand command)
        {
            userDto.Id = id;
            executor.ExecuteCommand(command, userDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
