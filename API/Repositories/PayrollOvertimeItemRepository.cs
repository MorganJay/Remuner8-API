using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollOvertimeItemRepository : IPayrollOvertimeItemRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollOvertimeItemRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task AddItemAsync(PayrollOvertimeItem payrollOvertimeItem)
        {
            await _remuner8Context.PayrollOvertimeItems.AddAsync(payrollOvertimeItem);
        }

        public async Task DeleteItem(int id)
        {
            var item = await _remuner8Context.PayrollOvertimeItems.FindAsync(id);
            if (item != null)
            {
                _remuner8Context.PayrollOvertimeItems.Remove(item);
            }
        }

        public async Task<IEnumerable<PayrollOvertimeItem>> GetAllAsync()
        {
            return await _remuner8Context.PayrollOvertimeItems.ToListAsync();
        }

        public async Task<PayrollOvertimeItem> GetItemAsync(int id)
        {
            var item = await _remuner8Context.PayrollOvertimeItems.FindAsync(id);
            return item;
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }

        public async Task UpdateItem(int id, PayrollOvertimeItem payrollOvertimeItem)
        {
            await _remuner8Context.SaveChangesAsync();
        }
    }
}