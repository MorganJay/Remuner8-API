using API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
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