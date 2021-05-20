using API.Infrastructure.Authentication;
using API.Core.Entities;
using System;
using System.Threading.Tasks;

namespace API.Infrastructure.Services
{
    public interface IUserService
    {
        Task<RegistrationResponse> GenerateJwtToken(ApplicationUser user);

        string RandomString(int length);

        Task<RegistrationResponse> VerifyToken(TokenRequest tokenRequest);

        DateTime UnixTimeStampToDateTime(double unixTimeStamp);
    }
}