namespace API.Repositories
{
    public class UserAccountsRepository : IUserAccountRepository
    {
        //private readonly Remuner8Context remuner8Context;

        //public UserAccountsRepository(Remuner8Context Context)
        //{
        //    remuner8Context = Context;
        //}

        //public async Task AddUserAsync(Password password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException(nameof(password));
        //    }
        //    await remuner8Context.Passwords.AddAsync(password);
        //}

        //public void DeleteUser(Password password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException(nameof(password));
        //    }
        //    remuner8Context.Passwords.Remove(password);
        //}

        //public void EditUser(Password password)
        //{
        //    remuner8Context.Passwords.Update(password);
        //}

        //public async Task<Password> GetUserAsync(string email)
        //{
        //    var user = await remuner8Context.Passwords.FindAsync(email);
        //    return user;
        //}

        //public async Task<IEnumerable<Password>> GetUsersAsync()
        //{
        //    return await remuner8Context.Passwords.ToListAsync();
        //}

        //public async Task<bool> SaveChangesAsync()
        //{
        //    return await remuner8Context.SaveChangesAsync() >= 0;
        //}

        //public async Task<bool> ValidateCredentialsAsync(PasswordReadDto model)
        //{
        //    try
        //    {
        //        var confirmCredentials = await remuner8Context.Passwords.Where(s => s.Password1 == model.Password1 && s.Email == model.Email).FirstOrDefaultAsync();
        //        if (confirmCredentials != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}