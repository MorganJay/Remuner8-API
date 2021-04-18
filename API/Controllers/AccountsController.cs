using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailServiceRepository _mailService;
        

        public AccountsController(UserManager<ApplicationUser> userManager, IMailServiceRepository mailService,
                IUserService userService)
        {
            _userService = userService;
            _userManager = userManager;
            _mailService = mailService;
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new RegistrationResponse
                {
                    Errors = new List<string>() { "Email already in use" },
                    Success = false,
                    Message = "Email already in use. Try a different email address"
                });


                var existingUser = await _userManager.FindByEmailAsync(model.Email);

                if (existingUser is not null)
                {
                    return BadRequest(new Response { Status = "Not successful", Message = "That user already exists" , Success= false });
                }

                var newUser = new ApplicationUser() { Email = model.Email, UserName = model.UserName };
                var isCreated = await _userManager.CreateAsync(newUser, model.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = await _userService.GenerateJwtToken(newUser);
                    return Ok(jwtToken);

                }
                else
                {
                    return BadRequest(new RegistrationResponse
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false,
                        Status = "Error"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var verifyEmail = await _userManager.FindByEmailAsync(model.Email);
                    if (verifyEmail is not null)
                    {
                        var verifyPassword = await _userManager.CheckPasswordAsync(verifyEmail, model.Password);
                        if (verifyPassword == true)
                        {
                            await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                            var jwtToken = await _userService.GenerateJwtToken(verifyEmail);
                            return Ok(jwtToken);
                        }
                    }

                    return Unauthorized(new RegistrationResponse
                    {
                        Errors = new List<string>(){
                        "Invalid login request"
                    },
                        Success = false
                    });
                }

                return BadRequest(new Response { Status = "Not sucessful", Message = "The data is not valid please enter valid data" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterReadDto>>> GetAllUsers()
        {
            try
            {
                var listOfUser = new List<RegisterReadDto>();
                var users = await _userManager.Users.ToListAsync();
                foreach (var item in users)
                {
                    var registeredUser = new RegisterReadDto()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Email = item.Email
                    };
                    listOfUser.Add(registeredUser);
                }
                return Ok(listOfUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Source });
            }
        }


        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.VerifyToken(tokenRequest);

                if (res == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                    "Invalid tokens"
                },
                        Success = false
                    });
                }

                return Ok(res);
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                "Invalid payload"
            },
                Success = false
            });

        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ApplicationUser user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return NotFound();
            }

            var result = await _mailService.ForgetPasswordAsync(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}