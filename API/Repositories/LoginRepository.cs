using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;
using System;
using System.Linq;

namespace Remuner8_Backend.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Remuner8Context context;

        public LoginRepository(Remuner8Context context)
        {
            this.context = context;
        }

        public bool ValidateCredentials(PasswordModel model)
        {
            try
            {
                var confirmCredentials = context.Passwords.Where(s => s.Password1 == model.Password && s.Email == model.Email).FirstOrDefault();
                if (confirmCredentials != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}