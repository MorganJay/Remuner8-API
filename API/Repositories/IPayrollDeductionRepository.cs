using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollDeductionRepository
    {
        Task<IEnumerable<PayrollDeductionItem>> GetItemsAsync();
        Task<PayrollDeductionItem> GetItemAsync(int id);
        Task AddItemsAsync(PayrollDeductionItem payrollDeductionItem);
        void EditItems(PayrollDeductionItem payrollDeductionItem);
        Task RemoveItemAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
