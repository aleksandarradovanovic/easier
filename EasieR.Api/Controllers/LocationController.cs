using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands.LocationCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.LocationQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly UseCasesExecutor executor;

        public LocationController(UseCasesExecutor executor)
        {
            this.executor = executor;
        }


        // GET: api/Location
        [HttpGet]
        public IActionResult Get([FromQuery] LocationSearch search, [FromServices] IGetLocationQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));

        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneLocationQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Location
        [HttpPost]
        public IActionResult Post([FromBody] LocationDto locationDto, [FromServices] ICreateLocationCommand command)
        {
            executor.ExecuteCommand(command, locationDto);
            return StatusCode(201, new { message = "Location created." });
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocationDto locationDto, [FromServices] IUpdateLocationCommand command)
        {
            locationDto.Id = id;
            executor.ExecuteCommand(command, locationDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLocationCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
