using API.Authentication;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PasswordRecoveryRepository : IPasswordRecoveryRepository
    {
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly IConfiguration _configuration;
         private readonly EmailSenderRepository _emailSender;

        public PasswordRecoveryRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration, EmailSenderRepository emailSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task<RegistrationResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new RegistrationResponse
                {
                    Message = "No user associated with email",
                    Success = false
                };
            }
            return new RegistrationResponse { Success = true };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/resetpassword?email-{email}&token-{validToken}";
            //await _emailSender.EmailSender(email, "Reset Password", "<hi>Follow the instructions to reset your Password</h1>");

        }
    }
}
