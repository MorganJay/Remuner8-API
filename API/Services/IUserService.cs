using API.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserService
    {
        Task<RegistrationResponse> GenerateJwtToken(IdentityUser user);
        string RandomString(int length);
        Task<RegistrationResponse> VerifyToken(TokenRequest tokenRequest);
        DateTime UnixTimeStampToDateTime(double unixTimeStamp);
    }
}
