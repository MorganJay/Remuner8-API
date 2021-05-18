using API.Authentication;
using API.Dtos;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<ApplicationUser> userManager, IMailServiceRepository mailService, IConfiguration configuration,
                IUserService userService)
        {
            _userService = userService;
            _userManager = userManager;
            _mailService = mailService;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterDto model)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);

                if (existingUser is not null)
                {
                    return BadRequest(new Response { Message = "A user with that email already exists", Success = false });
                }

                var newUser = new ApplicationUser { Email = model.Email, UserName = model.UserName };
                var isCreated = await _userManager.CreateAsync(newUser, model.Password);
                if (isCreated.Succeeded)
                {
                    var response = await _mailService.SendEmailAsync(newUser.Email, "Welcome to Remuner8!", "Thank you for signing up on <strong>Remuner8</strong>.<p>Your life is about to change for the better.</p>");
                    if (!response.IsSuccessStatusCode)
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new { Success = false, Message = "Mail Service failed", Response = response.Body });

                    var jwtToken = await _userService.GenerateJwtToken(newUser);
                    jwtToken.Message = "User created successfully";
                    jwtToken.UserName = newUser.UserName;
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest(new RegistrationResponse
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
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
                            await _mailService.SendEmailAsync(model.Email, "New Login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                            var jwtToken = await _userService.GenerateJwtToken(verifyEmail);
                            jwtToken.UserName = verifyEmail.UserName;
                            return Ok(jwtToken);
                        }
                    }

                    return Unauthorized(new RegistrationResponse
                    {
                        Errors = new List<string>(){
                        "Invalid login request"
                    },
                        Success = false,
                        Message = "Wrong Username or Password"
                    });
                }

                return BadRequest(new Response { Message = "The data is not valid please enter valid data", Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
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
                        "Invalid token"
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

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ApplicationUser user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return NotFound();
            }

            var result = await _mailService.ForgetPasswordAsync(user);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={user.Email}&token={validToken}";

            await _mailService.SendEmailAsync(user.Email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{url}'>Click Here</a></p>");

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] PasswordReset model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mailService.ResetPasswordAsync(model);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}