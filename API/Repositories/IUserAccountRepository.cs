using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Remuner8_Backend.EntityModels;

namespace Remuner8_Backend.Repositories
{
    public interface IUserAccountRepository
    {
        // Registration Methods
        IEnumerable<Password> GetUsers();

        Task<Password> GetUserAsync(string password);

        Task AddUserAsync(Password password);

        Task DeleteUserAsync(Password password);

        void EditUser(Password password);

        // Login Method
        bool ValidateCredentials(PasswordReadDto model);
    }
}