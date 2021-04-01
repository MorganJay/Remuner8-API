using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollItemsRepository : IPayrollItemsRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollItemsRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task AddEntryAsync(PayrollAdditionItem payrollAdditionItem)
        {
            await _remuner8Context.PayrollAdditionItems.AddAsync(payrollAdditionItem);
        }

        public void EditEntry(Task<PayrollAdditionItem> entryModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PayrollAdditionItem>> GetEntriesAsync()
        {
            return await _remuner8Context.PayrollAdditionItems.ToListAsync();
        }

        public async Task<PayrollAdditionItem> GetEntryAsync(int id)
        {
            var entry = await _remuner8Context.PayrollAdditionItems.FindAsync(id);
            return entry;
        }

        public async Task RemoveEntryAsync(int id)
        {
            var entry = await _remuner8Context.PayrollAdditionItems.FindAsync(id);
            _remuner8Context.PayrollAdditionItems.Remove(entry);
        }

        public async Task<bool> SavechangesAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}