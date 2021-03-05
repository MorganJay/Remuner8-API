using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollItemsRepository : IPayrollItemsRepository
    {
        private readonly Remuner8Context remuner8Context;

        public PayrollItemsRepository(Remuner8Context _remuner8Context)
        {
            remuner8Context = _remuner8Context;
        }

        public async Task AddEntryAsync(PayrollAdditionItem payrollAdditionItem)
        {
            await remuner8Context.PayrollAdditionItems.AddAsync(payrollAdditionItem);
            await remuner8Context.SaveChangesAsync();
        }

        public async Task EditEntryAsync(PayrollAdditionItem payrollAdditionItem)
        {
            var userId = await remuner8Context.PayrollAdditionItems.FindAsync(payrollAdditionItem.Id);
            if (userId != null)
            {
                remuner8Context.PayrollAdditionItems.Update(payrollAdditionItem);
                await remuner8Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }

        public async Task<IEnumerable<PayrollAdditionItem>> GetEntriesAsync()
        {
            return await remuner8Context.PayrollAdditionItems.ToListAsync();
        }

        public async Task<PayrollAdditionItem> GetEntryAsync(int id)
        {
            var entry = await remuner8Context.PayrollAdditionItems.FindAsync(id);
            await remuner8Context.SaveChangesAsync();
            return entry;

        }

        public async Task RemoveEntryAsync(int id)
        {
            var entry = await remuner8Context.PayrollAdditionItems.FindAsync(id);
            remuner8Context.PayrollAdditionItems.Remove(entry);
            await remuner8Context.SaveChangesAsync();
        }
    }
}
