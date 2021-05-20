using API.Core.Dtos;
using API.Core.Entities;
using API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Infrastructure.Data.EntityFramework.Repositories
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

        public void UpdateAsync(SystemDefaultDto company)
        {
        }
    }
}