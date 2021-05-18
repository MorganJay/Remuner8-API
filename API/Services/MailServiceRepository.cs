using API.Authentication;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class MailServiceRepository : IMailServiceRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public MailServiceRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<SendGrid.Response> SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGrid:SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("james.morgan@thebulb.africa", "Remuner8");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);

            return response;
        }

        //Confirm Email
        //public async Task<RegistrationResponse> ConfirmEmailAsync(string userId, string token)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return new RegistrationResponse { Message = "User not found", Success = false };
        //    }
        //    var decodedToken = WebEncoders.Base64UrlDecode(token);
        //    string normalToken = Encoding.UTF8.GetString(decodedToken);

        //    var result = await _userManager.ConfirmEmailAsync(user, normalToken);
        //    if (result.Succeeded)
        //    {
        //        return new RegistrationResponse { Message = "Email confirmed successfully", Success = true };
        //    }

        //    return new RegistrationResponse { Success = false, Message = "Email could not be confirmed", Errors = new List<string>(result.Errors.Select(e => e.Description)) };
        //}

        public async Task<RegistrationResponse> ForgetPasswordAsync(ApplicationUser applicationUser)
        {
            var user = await _userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                return new RegistrationResponse
                {
                    Message = "No user associated with email exists",
                    Success = false
                };
            }
            //var token = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            //var encodedToken = Encoding.UTF8.GetBytes(token);
            //var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            //string url = $"{_configuration["AppUrl"]}/ResetPassword?email={applicationUser.Email}&token={validToken}";

            //await _mailService.SendEmailAsync(applicationUser.Email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
            //    $"<p>To reset your password <a href='{url}'>Click Here</a></p>");

            return new RegistrationResponse
            {
                Message = "Reset password link has been sent to your email successfully!",
                Success = true
            };
        }

        public async Task<RegistrationResponse> ResetPasswordAsync(PasswordReset model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new RegistrationResponse
                {
                    Message = "No user found associated with email",
                    Success = false
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new RegistrationResponse
                {
                    Message = "Passwords do not match",
                    Success = false
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new RegistrationResponse
                {
                    Message = "Password has been reset successfully!",
                    Success = true
                };

            return new RegistrationResponse
            {
                Message = "Something went wrong",
                Success = false,
                Errors = new List<string>(result.Errors.Select(e => e.Description))
            };
        }
    }
}