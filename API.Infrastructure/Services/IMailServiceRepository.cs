using API.Infrastructure.Authentication;
using API.Core.Dtos;
using API.Core.Entities;
using System.Threading.Tasks;

namespace API.Infrastructure.Services
{
    public interface IMailServiceRepository
    {
        Task<SendGrid.Response> SendEmailAsync(string toEmail, string subject, string content);

        Task<RegistrationResponse> ForgetPasswordAsync(ApplicationUser applicationUser);

        Task<RegistrationResponse> ResetPasswordAsync(PasswordReset model);

        //Task<RegistrationResponse> ConfirmEmailAsync(string userId, string token);
    }
}