using API.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Remuner8_Backend.Dtos;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8_Backend.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserAccountRepository RegisterRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;

        public RegisterController(IUserAccountRepository registerRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper, ILogger logger)
        {
            RegisterRepository = registerRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            // _logger = logger;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult<IEnumerable<PasswordReadDto>>> GetUsersAsync()
        {
            try
            {
                return Ok(await RegisterRepository.GetUsersAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{email}")]
        public async Task<ActionResult<PasswordReadDto>> GetUserAsync(string email)
        {
            try
            {
                var userItem = await RegisterRepository.GetUserAsync(email);
                if (userItem is not null)
                {
                    return Ok(_mapper.Map<PasswordReadDto>(userItem));
                }
                return NotFound($"User with email: {email} was not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
        }

        //[HttpPost]
        //[Route("api/[controller]")]
        //public async Task<ActionResult<PasswordReadDto>> AddUserAsync(PasswordCreateDto passwordcreatedto)
        //{
        //    try
        //    {
        //        var passwordmodel = _mapper.Map<Password>(passwordcreatedto);
        //        var userExists = await RegisterRepository.GetUserAsync(passwordcreatedto.Email);
        //        if (userExists == null)
        //        {
        //            await RegisterRepository.AddUserAsync(passwordmodel);
        //            await RegisterRepository.SaveChangesAsync();
        //            var passwordreaddto = _mapper.Map<PasswordReadDto>(passwordmodel);
        //            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User Created Successfully" });
        //        }
        //        return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "User Already Exists" });
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
        //    }
        //}

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddUserAsync(PasswordCreateDto passwordCreateDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = passwordCreateDto.Email,
                Email = passwordCreateDto.Email
            };
            var signInUser = await _userManager.CreateAsync(identityUser);
            if (signInUser.Succeeded)
            {
                await _signInManager.SignInAsync(identityUser, true);
                return Ok(identityUser);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        public async Task<IActionResult> DeleteUserAsync(string email)
        {
            try
            {
                var user = await RegisterRepository.GetUserAsync(email);

                if (user != null)
                {
                    RegisterRepository.DeleteUser(user);
                    return Ok(new Response { Status = "Success", Message = "User Deleted Successfully" });
                }
                return NotFound($"User with email: {email} was not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
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