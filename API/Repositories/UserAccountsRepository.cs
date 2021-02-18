using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Remuner8_Backend.Repositories
{
    public class UserAccountsRepository : IUserAccountRepository
    {
        private readonly Remuner8Context remuner8Context;

        public UserAccountsRepository(Remuner8Context Context)
        {
            remuner8Context = Context;
        }

        public Password AddUser(Password password)
        {
            remuner8Context.Passwords.Add(password);
            remuner8Context.SaveChanges();
            return password;
        }

        public void DeleteUser(Password password)
        {
            remuner8Context.Passwords.Remove(password);
            remuner8Context.SaveChanges();
        }

        public Password EditUser(Password password)
        {
            remuner8Context.Passwords.Update(password);
            remuner8Context.SaveChanges();
            return password;
        }

        public Password GetUser(string email)
        {
            var user = remuner8Context.Passwords.Find(email);
            return user;
        }

        public List<Password> GetUsers()
        {
            return remuner8Context.Passwords.ToList();
        }

        public bool ValidateCredentials(PasswordModel model)
        {
            try
            {
                var confirmCredentials = remuner8Context.Passwords.Where(s => s.Password1 == model.Password && s.Email == model.Email).FirstOrDefault();
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