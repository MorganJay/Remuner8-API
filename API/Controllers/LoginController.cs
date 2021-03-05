 using API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Repositories;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAccountRepository login;

        public LoginController(IUserAccountRepository login)
        {
            this.login = login;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult> Validate([FromBody] PasswordReadDto model)
        {
            try
            {
                if (await login.ValidateCredentialsAsync(model))
                {
                    return Ok(new Response { Status = "Success", Message = "Login Successful" });
                }
                return NotFound(new Response { Status = "Failure", Message = "Login Unsuccessful\nInvalid Username or Password." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Login Not Successful | Server Unreachable" });
            }
        }
    }
}