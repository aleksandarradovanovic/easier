using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasieR.Api.Core;
using EasieR.Application.DataTransfer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasieR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtManager jwtManager;

        public LoginController(JwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto loginDto)
        {
            if(loginDto.UserName == null || loginDto.Password == null)
            {
                return BadRequest();
            }
            var jwt = jwtManager.MakeToken(loginDto.UserName, loginDto.Password);
            if(jwt == null) {
                return StatusCode(500,new ResultDto { 
                message = "Bad credentials"
                });
            }
            return Ok(new ResultDto
            {
                message = "Login success",
                data = jwt
            });
        }

        // PUT: api/Login/5
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
