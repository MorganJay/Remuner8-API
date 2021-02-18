using Remuner8_Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Remuner8_Backend.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly Remuner8Context remuner8Context;

        public RegisterRepository(Remuner8Context Context)
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
    }
}