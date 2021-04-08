using API.Authentication;
using API.Dtos;
using API.Models;
using API.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IOptionsMonitor<JwtSettings> _optionsMonitor;

        public AccountController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtSettings> optionsMonitor)
        {
            _userManager = userManager;
            _jwtSettings = optionsMonitor.CurrentValue;
        }

        // GET: api/<AccountController>

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new RegistrationResponse { Errors = new List<string>(){"Email already in use"},
                    Success = false });

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var exist = await _userManager.FindByEmailAsync(model.Email);

                if (exist is not null)
                {
                    return BadRequest(new Response { Status = "Not successful", Message = "That user already exists" , Success= false });
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.UserName };
                var isCreated = await _userManager.CreateAsync(user, model.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);
                    return Ok(new RegistrationResponse { Success = true, Token = jwtToken });
                  
                }
                else
                {
                    return BadRequest(new RegistrationResponse { Errors = isCreated.Errors.Select(x => x.Description).ToList(), Success = false }
                    );
                }
                //return Ok(new Response { Status = "Success", Message = "You have sucessfully registered", Success = true});
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var verifyEmail = await _userManager.FindByEmailAsync(model.Email);
                    if (verifyEmail is not null)
                    {
                        var verifyPassword = await _userManager.CheckPasswordAsync(verifyEmail, model.Password);
                        if (verifyPassword)
                        {
                            return Ok(new Response { Status = "Success", Message = "You are verified" });
                        }
                    }

                    return Unauthorized(new Response { Status = "Error", Message = "User does not exist" });
                }

                return BadRequest(new Response { Status = "Error", Message = "The data is not valid please enter valid data" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Source });
            }
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;

        }
    }
}