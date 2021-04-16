using API.Authentication;
using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserServices
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterDto model);
        Task<RegistrationResponse> LoginUserAsync(LoginDto model);
        Task<RegistrationResponse> ConfirmEmailAsync(string userId, string token);
        Task<RegistrationResponse> ForgetPasswordAsync(string email);


    }


}
