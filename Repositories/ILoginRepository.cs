using Remuner8.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remuner8.Repositories
{
   public  interface ILoginRepository
    {
        bool ValidateCredentials(PasswordModel model);
    }
}
