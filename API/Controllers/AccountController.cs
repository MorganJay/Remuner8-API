using API.Authentication;
using API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Remuner8_Backend.Dtos;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        // GET: api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterDto model)
        {
            try
            {
                if (ModelState.IsValid || model is null)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                    var exist = await _userManager.FindByEmailAsync(model.Email);

                    if (exist is null)
                    {
                        return BadRequest(new Response { Status = "Not sucessful", Message = "The Email already exist" });
                    }
                    await _userManager.CreateAsync(user, model.Password);
                    return Ok(new Response { Status = " success", Message = "You have sucessfully registered" });
                }
                return BadRequest(new Response { Status = "Not sucessful", Message = "The data is not valid please enter valid data" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var verifyEmail = await _userManager.FindByEmailAsync(model.Email);
                    var user = new IdentityUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };

                    var verifyPassword = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (verifyEmail is not null && verifyPassword)
                    {
                        return Ok(new Response { Status = "Success", Message = "You are verified" });
                    }
                    return Unauthorized(new Response { Status = "Not sucessful", Message = "The data is not in the database " });
                }

                return BadRequest(new Response { Status = "Not sucessful", Message = "The data is not valid please enter valid data" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}