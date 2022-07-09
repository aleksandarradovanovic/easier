using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.ReservationQueries;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly UseCasesExecutor executor;

        public ReservationController(UseCasesExecutor executor)
        {
            this.executor = executor;
        }
        // GET: api/Reservation
        [HttpGet]
        public IActionResult Get([FromQuery] ReservationSearch search, [FromServices] IGetReservationsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneReservationQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }
        // GET: api/Reservation/validate
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] ReservationValidationRo reservationValidationRo, [FromServices] IValidateReservationCommand command, [FromServices] IGetOneReservationQuery query)
        {
            executor.ExecuteCommand(command, reservationValidationRo);
            return Ok(executor.ExecuteQuery(query, reservationValidationRo.Id));
        }

        // POST: api/Reservation
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDtos reservationDtos, [FromServices] ICreateReservationCommand command)
        {
            executor.ExecuteCommand(command, reservationDtos);
            return StatusCode(201, new { message = "Reservation created" });
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservationDto reservationDto, [FromServices] IUpdateReservationCommand command)
        {
            executor.ExecuteCommand(command, reservationDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReservationCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
