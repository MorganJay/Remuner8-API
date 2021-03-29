using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Remuner8_Backend.EntityModels;

namespace Remuner8_Backend.Repositories
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<Password>> GetUsersAsync();

        Task<Password> GetUserAsync(string password);

        Task AddUserAsync(Password password);

        void DeleteUser(Password password);

        Task<bool> SaveChangesAsync();

        //void EditUser(Password password);
        Task<bool> ValidateCredentialsAsync(PasswordReadDto model);
    }
}