using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollRateRepository
    {
        Task<IEnumerable<PayrollRate>> GetAllRatesAsync();
        Task<PayrollRate> GetRateByIdAsync(int id);
        Task CreateRateAsync(PayrollRate payrollRate);
        void EditRate(int id, PayrollRate payrollRate);
        void DeleteRate(PayrollRate payrollRate);
        Task<bool> SaveAsync();
    }
}
