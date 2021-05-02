using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollRateRepository : IPayrollRateRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollRateRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateRateAsync(PayrollRate payrollRate)
        {
            await _remuner8Context.PayrollRates.AddAsync(payrollRate);
        }

        public void DeleteRate(PayrollRate payrollRate)
        {
            _remuner8Context.PayrollRates.Remove(payrollRate);
        }

        public void EditRate(int id, PayrollRate payrollRate)
        {
        }

        public async Task<IEnumerable<PayrollRate>> GetAllRatesAsync()
        {
            var rates = await _remuner8Context.PayrollRates.ToListAsync();
            return rates;
        }

        public async Task<PayrollRate> GetRateByIdAsync(int id)
        {
            var rate = await _remuner8Context.PayrollRates.FindAsync(id);
            return rate;
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}