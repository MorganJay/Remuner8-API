using Remuner8.EntityModels;
using Remuner8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remuner8.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly db_payrollappContext context;

        public LoginRepository(db_payrollappContext context)
        {
            this.context = context;
        }
       
        public bool ValidateCredentials(PasswordModel model)
        {
            try
            {
                var confirmcredentials = context.Passwords.Where(s => s.Password1 == model.Password && s.Email == model.Email).FirstOrDefault();
                if (confirmcredentials== null)
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

