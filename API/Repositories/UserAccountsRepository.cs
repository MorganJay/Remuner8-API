using API.Models;
using Microsoft.EntityFrameworkCore;
using Remuner8_Backend.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remuner8_Backend.Repositories
{
    public class UserAccountsRepository : IUserAccountRepository
    {
        private readonly Remuner8Context remuner8Context;

        public UserAccountsRepository(Remuner8Context Context)
        {
            remuner8Context = Context;
        }

        public async Task AddUserAsync(Password password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            await remuner8Context.Passwords.AddAsync(password);
            await remuner8Context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Password password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            remuner8Context.Passwords.Remove(password);
            await remuner8Context.SaveChangesAsync();
        }

        public void EditUser(Password password)
        {
            remuner8Context.Passwords.Update(password);
            remuner8Context.SaveChanges();
        }

        public async Task<Password> GetUserAsync(string email)
        {
            var user = await remuner8Context.Passwords.FindAsync(email);
            return user;
        }

        public async Task<IEnumerable<Password>> GetUsersAsync()
        {
            return await remuner8Context.Passwords.ToListAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(PasswordReadDto model)
        {
            try
            {
                var confirmCredentials = await remuner8Context.Passwords.Where(s => s.Password1 == model.Password1 && s.Email == model.Email).FirstOrDefaultAsync();
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