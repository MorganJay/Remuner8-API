using API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
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