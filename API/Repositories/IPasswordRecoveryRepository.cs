using API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPasswordRecoveryRepository
    {
        Task<RegistrationResponse> ForgetPasswordAsync(string email);
    }
}
