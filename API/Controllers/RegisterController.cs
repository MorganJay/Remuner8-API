using API;
using API.Authentication;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.Dtos;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8_Backend.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserAccountRepository RegisterRepository;
        private readonly IMapper _mapper;

        public RegisterController(IUserAccountRepository registerRepository, IMapper mapper)
        {
            RegisterRepository = registerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult <IEnumerable<PasswordReadDto>>> GetUsersAsync()
        {
            return Ok(await RegisterRepository.GetUsersAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{email}")]
        public async Task<ActionResult <PasswordReadDto>> GetUserAsync(string email)
        {
            var userItem = await RegisterRepository.GetUserAsync(email);
            if (userItem != null)
            {
                return Ok(_mapper.Map<PasswordReadDto>(userItem));
            }
            return NotFound($"User with email: {email} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult <PasswordReadDto>> AddUserAsync(PasswordCreateDto passwordcreatedto)
        {
            var passwordmodel = _mapper.Map<Password>(passwordcreatedto);
            var userExists = await RegisterRepository.GetUserAsync(passwordcreatedto.Email);
            if (userExists == null)
            {
                await RegisterRepository.AddUserAsync(passwordmodel);
                var passwordreaddto = _mapper.Map<PasswordReadDto>(passwordmodel);
                return Ok((passwordreaddto));
            }
            return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "User Already Exists" });
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        public async Task<IActionResult> DeleteUserAsync(string email)
        {
            var user = await RegisterRepository.GetUserAsync(email);

            if (user != null)
            {
                await RegisterRepository.DeleteUserAsync(user);
                return Ok(new Response { Status = "Success", Message = "User Deleted Successfully" });
            }
            return NotFound($"User with email: {email} was not found");
        }

        //[HttpPatch]
        //[Route("api/[controller]/{email}")]
        //public IActionResult EditUser(Password password)
        //{
        //    var existingUser = await RegisterRepository.GetUserAsync(password.Email);
        //    if (existingUser != null)
        //    {
        //        // password.Password1 = existingUser.Password1;
        //        RegisterRepository.EditUser(password);
        //    }
        //    return Ok(password);
        //}
    }
}