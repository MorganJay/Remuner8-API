using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remuner8_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,IEmailSender emailSender)
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
        }

        // GET: api/<AccountController>
        
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterDto model)
        {
            try
            {
                
                if (ModelState.IsValid )
                {
                    var user = new ApplicationUser
                    {
                        UserName=model.UserName,
                        Email = model.Email
                    };
                    var exist = await _userManager.FindByEmailAsync(model.Email);

                    if (exist is not null)
                    {
                        return BadRequest(new Response { Status = "Not sucessful", Message = "The Email already exist" });
                    }
                 var registeredUser=   await _userManager.CreateAsync(user, model.Password);
                    if (registeredUser.Succeeded)
                    {
                        var message = new Message
                        {
                            To = new List<string> { "Test@test.com" }
                        };
                        await _emailSender.EmailSender(message);
                        return Ok(new Response { Status = " success", Message = "You have sucessfully registered" });

                    }
                 
                }
                return BadRequest(new Response { Status = "Not sucessful", Message = "The data is not valid please enter valid data" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string >> Login([FromBody]LoginDto model, string userName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var verifyEmail = await _userManager.FindByEmailAsync(model.Email );
                    if (verifyEmail is not null)
                    { 
                        
                       

                        var verifyPassword = await _userManager.CheckPasswordAsync(verifyEmail, model.Password);
                        if (verifyPassword)
                        {

                            userName = verifyEmail.UserName;
                           
                            return Ok( userName);

                        }

                       
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
        [HttpGet]
        public async Task< ActionResult<IEnumerable<RegisterReadDto>>> GetAllUsers()
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
            catch (Exception)
            {


                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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