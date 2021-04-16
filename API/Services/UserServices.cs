using API.Authentication;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserServices : IUserServices
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        public UserServices(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public Task<RegistrationResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new RegistrationResponse 
                { 
                    Message = "User did not create",
                    Success = false,
                    Errors = Errors.Select(e => e.Description)
                    
                }
            }
        } 
        
    }
}
