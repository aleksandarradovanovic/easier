using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands.EventCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.EventQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly UseCasesExecutor executor;

        public EventController(UseCasesExecutor executor)
        {
            this.executor = executor;
        }
        // GET: api/Event
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] EventSearch search, [FromServices] IGetEventsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
        // GET: api/Event/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneEventQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Event
        [HttpPost]
        public IActionResult Post([FromBody] EventDto eventDto, [FromServices] ICreateEventCommand command)
        {
            executor.ExecuteCommand(command, eventDto);
            return StatusCode(201, new { message = "Event created." });
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventDto eventDto, [FromServices] IUpdateEventCommand command)
        {
            eventDto.Id = id;
            executor.ExecuteCommand(command, eventDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteEventCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
