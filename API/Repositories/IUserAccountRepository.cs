using System.Collections.Generic;
using API.Models;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;

namespace Remuner8_Backend.Repositories
{
    public interface IUserAccountRepository
    {
        IEnumerable<Password> GetUsers();

        Password GetUser(string password);

        void AddUser(Password password);

        void DeleteUser(Password password);

        void EditUser(Password password);
        bool ValidateCredentials(PasswordReadDto model);
    }
}