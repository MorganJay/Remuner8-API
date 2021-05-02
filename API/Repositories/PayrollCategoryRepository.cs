using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayrollCategoryRepository : IPayrollCategoryRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayrollCategoryRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateCategoryAsync(PayrollCategory payrollCategory)
        {
            await _remuner8Context.PayrollCategories.AddAsync(payrollCategory);
        }

        public void DeleteCategory(int id)
        {
            var category = _remuner8Context.PayrollCategories.Find(id);
            if (category != null)
            {
                _remuner8Context.PayrollCategories.Remove(category);
            }
        }

        public void EditCategory(int id, PayrollCategory payrollCategory)
        {
        }

        public async Task<IEnumerable<PayrollCategory>> GetAllCategoriesAsync()
        {
            var category = await _remuner8Context.PayrollCategories.ToListAsync();
            return category;
        }

        public async Task<PayrollCategory> GetCategoryByIdAsync(int id)
        {
            var category = await _remuner8Context.PayrollCategories.FindAsync(id);
            return category;
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}