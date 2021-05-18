using API.Authentication;
using API.Models;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMailServiceRepository
    {
        Task<SendGrid.Response> SendEmailAsync(string toEmail, string subject, string content);

        Task<RegistrationResponse> ForgetPasswordAsync(ApplicationUser applicationUser);

        Task<RegistrationResponse> ResetPasswordAsync(PasswordReset model);

        //Task<RegistrationResponse> ConfirmEmailAsync(string userId, string token);
    }
}