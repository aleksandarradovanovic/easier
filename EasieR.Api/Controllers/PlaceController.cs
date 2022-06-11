using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands.PlaceCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.PlaceQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly UseCasesExecutor executor;
        private readonly IApplicationActor actor;


        public PlaceController(UseCasesExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Place
        [HttpGet]
        public IActionResult Get([FromQuery] PlaceSearch search, [FromServices] IGetPlacesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
        // GET: api/Place/staff
        [HttpGet("staff")]
        public IActionResult GetStaff([FromQuery] PlaceStaffSearch search, [FromServices] IGetPlaceStaffQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
        // GET: api/Place/user
        [HttpGet("user")]
        public IActionResult GetPlaceForUser([FromQuery] PlaceSearch search, [FromServices] IGetPlacesQuery query)
        {
            search.UserId = actor.Id;
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Place/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOnePlaceQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Place
        [HttpPost]
        public IActionResult Post([FromBody] PlaceDto placeDto, [FromServices] ICreatePlaceCommand command)
        {
            executor.ExecuteCommand(command, placeDto);
            return StatusCode(201, new ResultDto
            {
                message = "Place created"
            });
        }

        // PUT: api/Place/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlaceDto placeDto, [FromServices] IUpdatePlaceCommand command)
        {
            placeDto.Id = id;
            executor.ExecuteCommand(command, placeDto);
            return Ok(new ResultDto
            {
                message = "Place updated"
            });
        } 
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePlaceCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
