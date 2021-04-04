using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<SystemDefault>> GetCompanyDetailsAsync();

        Task CreateCompanyAsync(SystemDefault systemDefault);

        Task<bool> SaveAllAsync();

        void UpdateAsync(SystemDefault Company);
    }
}