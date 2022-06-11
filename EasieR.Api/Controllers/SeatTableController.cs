using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Application;
using EasieR.Application.Queries.SeatTable;
using EasieR.Application.SearchData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatTableController : ControllerBase
    {
        private readonly UseCasesExecutor executor;
        private readonly IApplicationActor actor;
        public SeatTableController(UseCasesExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/SeatTable
        [HttpGet]
        public IActionResult Get([FromQuery] SeatTableSearch search, [FromServices] IGetSeatTablesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/SeatTable/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SeatTable
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SeatTable/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
