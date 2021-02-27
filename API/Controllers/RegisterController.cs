using API.Authentication;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;
using Remuner8_Backend.Repositories;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<PasswordReadDto>> GetUsers()
        {
            return Ok(RegisterRepository.GetUsers());
        }

        [HttpGet]
        [Route("api/[controller]/{email}")]
        public ActionResult<PasswordReadDto> GetUser(string email)
        {
            var userItem = RegisterRepository.GetUser(email);
            if (userItem != null)
            {
                return Ok(_mapper.Map<PasswordReadDto>(userItem));
            }
            return NotFound($"User with email: {email} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<PasswordReadDto> AddUser(PasswordCreateDto passwordCreateDto)
        {
            var passwordModel = _mapper.Map<Password>(passwordCreateDto);
            var userExists = RegisterRepository.GetUser(passwordCreateDto.Email);
            if (userExists == null)
            {
                RegisterRepository.AddUser(passwordModel);
                var passwordReadDto = _mapper.Map<PasswordReadDto>(passwordModel);
                return (passwordReadDto);
            }
            return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "User Already Exists" });
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        public IActionResult DeleteUser(string email)
        {
            var user = RegisterRepository.GetUser(email);

            if (user != null)
            {
                RegisterRepository.DeleteUser(user);
                return Ok(new Response { Status = "Success", Message = "User Deleted Successfully" });
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