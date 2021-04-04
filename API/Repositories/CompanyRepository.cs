using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        //private readonly SystemDefault company;
        private readonly Remuner8Context company1;

        public CompanyRepository(Remuner8Context company)
        {
            company1 = company;
        }

        public async Task CreateCompanyAsync(SystemDefault systemDefault)
        {
            await company1.SystemDefaults.AddAsync(systemDefault);
        }

        public async Task<IEnumerable<SystemDefault>> GetCompanyDetailsAsync()
        {
            return await company1.SystemDefaults.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await company1.SaveChangesAsync() >= 0;
        }

        public void UpdateAsync(SystemDefault company)
        {
        }
    }
}