using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    interface IPayrollItemsRepository
    {
        // Additions methods
        Task<IEnumerable<PayrollAdditionItem>> GetEntriesAsync();

        Task<PayrollAdditionItem> GetEntryAsync(int id);

        Task AddEntryAsync(PayrollAdditionItem payrollAdditionItem);

        Task EditEntry(PayrollAdditionItem payrollAdditionItem);

        Task RemoveEntryAsync(PayrollAdditionItem payrollAdditionItem);
    }
}
