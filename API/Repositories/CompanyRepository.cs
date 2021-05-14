using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        //private readonly SystemDefault company;
        private readonly Remuner8Context context;

        public CompanyRepository(Remuner8Context company)
        {
            context = company;
        }

        public async Task CreateCompanyAsync(SystemDefault systemDefault)
        {
            await context.SystemDefaults.AddAsync(systemDefault);
        }

        public async Task<SystemDefault> GetCompanyDetailsAsync()
        {
            return await context.SystemDefaults.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        public void UpdateAsync(SystemDefault company)
        {
        }
    }
}