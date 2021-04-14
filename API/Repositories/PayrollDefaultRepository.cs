using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollDefaultRepository : IPayrollDefaultRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollDefaultRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateDefaultAsync(PayrollDefault payrollDefault)
        {
            await _remuner8Context.PayrollDefaults.AddAsync(payrollDefault);
        }

        public void DeleteDefault(int id)
        {
            var item = _remuner8Context.PayrollDefaults.Find(id);
            _remuner8Context.PayrollDefaults.Remove(item);
        }

        public void EditDefaultAsync(int id, PayrollDefault payrollDefault)
        {
            //
        }

        public async Task<IEnumerable<PayrollDefault>> GetAllDefaultsAsync()
        {
            var item = await _remuner8Context.PayrollDefaults.ToListAsync();
            return item;
        }

        public async Task<PayrollDefault> GetDefaultByIdAsync(int id)
        {
            var item = await _remuner8Context.PayrollDefaults.FindAsync(id);
            return item;
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}