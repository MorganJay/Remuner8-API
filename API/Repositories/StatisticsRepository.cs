using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Remuner8Context _context;

        public StatisticsRepository(Remuner8Context context)
        {
            _context = context;
        }

        public async Task<int> DepartmentsCountAsync()
        {
            return await _context.Departments.CountAsync();
        }

        public async Task<int> EmployeeCountAsync()
        {
            return await _context.EmployeeBiodatas.CountAsync();
        }
    }
}