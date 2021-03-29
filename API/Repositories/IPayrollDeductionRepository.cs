using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollDeductionRepository
    {
        Task<IEnumerable<PayrollDeductionItem>> GetAllItemsAsync();

        Task<PayrollDeductionItem> GetItemAsync(int id);

        Task AddItemsAsync(PayrollDeductionItem payrollDeductionItem);

        void EditItems(PayrollDeductionItem payrollDeductionItem);

        Task RemoveItemAsync(int id);

        Task<bool> SaveChangesAsync();
    }
}