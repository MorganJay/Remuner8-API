using API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Repositories;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAccountRepository login;


        // POST api/<LoginController>
        public LoginController(IUserAccountRepository login)
        {
            this.login = login;
        }

        // GET: api/<PasswordController>
        [HttpPost]
        public ActionResult Validate([FromBody] PasswordReadDto model)
        {
            try
            {
                if (login.ValidateCredentials(model))
                {
                    return Ok(new Response {Status="Success", Message="Login Successful" });
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = " Login Not Successful " });
            }
        }
    }
}