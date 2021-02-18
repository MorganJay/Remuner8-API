using System.Collections.Generic;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;

namespace Remuner8_Backend.Repositories
{
    public interface IUserAccountRepository
    {
        List<Password> GetUsers();

        Password GetUser(string password);

        Password AddUser(Password password);

        void DeleteUser(Password password);

        Password EditUser(Password password);
        bool ValidateCredentials(PasswordModel model);
    }
}