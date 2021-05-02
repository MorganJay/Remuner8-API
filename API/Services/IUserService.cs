using API.Authentication;
using API.Models;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserService
    {
        Task<RegistrationResponse> GenerateJwtToken(ApplicationUser user);
        string RandomString(int length);
        Task<RegistrationResponse> VerifyToken(TokenRequest tokenRequest);
        DateTime UnixTimeStampToDateTime(double unixTimeStamp);
        
    }
}
