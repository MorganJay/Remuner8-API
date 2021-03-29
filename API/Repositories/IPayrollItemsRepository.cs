using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollItemsRepository
    {
        // Additions methods
        Task<IEnumerable<PayrollAdditionItem>> GetEntriesAsync();

        Task<PayrollAdditionItem> GetEntryAsync(int id);

        Task AddEntryAsync(PayrollAdditionItem payrollAdditionItem);

        Task RemoveEntryAsync(int id);

        Task<bool> SavechangesAsync();

        void EditEntry(Task<PayrollAdditionItem> entryModel);
    }
}