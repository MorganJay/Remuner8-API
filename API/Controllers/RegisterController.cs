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
            RegisterRepository.AddUser(password);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + password.Email,
                password);
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        public IActionResult DeleteUser(string email)
        {
            var user = RegisterRepository.GetUser(email);

            if (user != null)
            {
                RegisterRepository.DeleteUser(user);
                return Ok();
            }
            return NotFound($"User with email: {email} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{email}")]
        public IActionResult EditUser(string email, Password password)
        {
            var existingUser = RegisterRepository.GetUser(email);
            if (existingUser != null)
            {
                password.Password1 = existingUser.Password1;
                RegisterRepository.EditUser(password);
            }
            return Ok(password);
        }
    }
}