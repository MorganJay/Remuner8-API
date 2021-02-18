using API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.Models;
using Remuner8_Backend.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8_Backend.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository RegisterRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            RegisterRepository = registerRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(RegisterRepository.GetUsers());
        }

        [HttpGet]
        [Route("api/[controller]/{email}")]
        public IActionResult GetUser(string email)
        {
            var user = RegisterRepository.GetUser(email);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with email: {email} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddUser([FromBody] Password password)
        {
            var userExists = RegisterRepository.GetUser(password.Email);
            if (userExists == null)
            {
                RegisterRepository.AddUser(password);
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User Successfully Created" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already Exists" });
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        public IActionResult DeleteUser(string email)
        {
            var user = RegisterRepository.GetUser(email);

            if (user != null)
            {
                RegisterRepository.DeleteUser(user);
                return Ok(new Response { Status = "Success", Message = $"User with email: {email} was not found" });
            }
            return NotFound($"User with email: {email} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{email}")]
        public IActionResult EditUser(Password password)
        {
            var existingUser = RegisterRepository.GetUser(password.Email);
            if (existingUser != null)
            {
                // password.Password1 = existingUser.Password1;
                RegisterRepository.EditUser(password);
            }
            return Ok(password);
        }
    }
}