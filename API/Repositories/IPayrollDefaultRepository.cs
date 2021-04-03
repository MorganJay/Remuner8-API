using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollDefaultRepository
    {
        Task<IEnumerable<PayrollDefault>> GetAllDefaultsAsync();
        Task<PayrollDefault> GetDefaultByIdAsync(int id);
        Task CreateDefaultAsync(PayrollDefault payrollDefault);
        void EditDefaultAsync(int id, PayrollDefault payrollDefault);
        void DeleteDefault(int id);
        Task<bool> SaveAsync();


    }
}
