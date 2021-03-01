using System.Collections.Generic;
using API.Models;
using Remuner8_Backend.EntityModels;

namespace Remuner8_Backend.Repositories
{
    public interface IUserAccountRepository
    {
        // Registration Methods
        IEnumerable<Password> GetUsers();

        Password GetUser(string password);

        void AddUser(Password password);

        void DeleteUser(Password password);

        void EditUser(Password password);

        // Login Method
        bool ValidateCredentials(PasswordReadDto model);
    }
}