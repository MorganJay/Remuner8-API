using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollOvertimeItemRepository
    {
        Task<IEnumerable<PayrollOvertimeItem>> GetAllAsync();

        Task<PayrollOvertimeItem> GetItemAsync(int id);

        Task AddItemAsync(PayrollOvertimeItem payrollOvertimeItem);

        Task UpdateItem(int id, PayrollOvertimeItem payrollOvertimeItem);

        Task DeleteItem(int id);

        Task<bool> SaveAsync();
    }
}