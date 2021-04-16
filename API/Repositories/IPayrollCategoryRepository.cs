using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPayrollCategoryRepository
    {
        Task<IEnumerable<PayrollCategory>> GetAllCategoriesAsync();

        Task<PayrollCategory> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(PayrollCategory payrollCategory);

        void EditCategory(int id, PayrollCategory payrollCategory);

        void DeleteCategory(int id);

        Task<bool> SaveAsync();
    }
}