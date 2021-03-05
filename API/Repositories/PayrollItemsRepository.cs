using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollItemsRepository : IPayrollItemsRepository
    {
        public async Task AddEntryAsync(PayrollAdditionItem payrollAdditionItem)
        {
            throw new NotImplementedException();
        }

        public Task EditEntry(PayrollAdditionItem payrollAdditionItem)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PayrollAdditionItem>> GetEntriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PayrollAdditionItem> GetEntryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveEntryAsync(PayrollAdditionItem payrollAdditionItem)
        {
            throw new NotImplementedException();
        }
    }
}
