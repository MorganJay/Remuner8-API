using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollDeductionRepository : IPayrollDeductionRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollDeductionRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task AddItemsAsync(PayrollDeductionItem payrollDeductionItem)
        {
            await _remuner8Context.PayrollDeductionItems.AddAsync(payrollDeductionItem);
        }

        public void EditItems(PayrollDeductionItem payrollDeductionItem)
        {
            throw new NotImplementedException();
        }

        public async Task<PayrollDeductionItem> GetItemAsync(int id)
        {
            var entry = await _remuner8Context.PayrollDeductionItems.FindAsync(id);
            return entry;
        }

        public async Task<IEnumerable<PayrollDeductionItem>> GetAllItemsAsync()
        {
            return await _remuner8Context.PayrollDeductionItems.ToListAsync();
        }

        public async Task RemoveItemAsync(int id)
        {
            var item = await _remuner8Context.PayrollDeductionItems.FindAsync(id);
            if (item != null)
            {
                _remuner8Context.PayrollDeductionItems.Remove(item);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}