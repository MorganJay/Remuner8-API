using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Remuner8Context context;

        public EmployeeRepository(Remuner8Context context)
        {
            this.context = context;
        }

        public async Task<int> EmployeeCountAsync()
        {
            return await context.EmployeeBiodatas.CountAsync();
        }

        public async Task<IEnumerable<EmployeeBiodata>> GetAllEmployeesAsync()
        {
            return await context.EmployeeBiodatas.ToListAsync();
        }

        public async Task<EmployeeBiodata> GetEmployeeByIdAsync(string id)
        {
            return await context.EmployeeBiodatas.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        public async Task CreateEmployeeAsync(EmployeeBiodata employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            await context.EmployeeBiodatas.AddAsync(employee);
        }

        public async Task DeleteEmployeeAsync(EmployeeBiodata employee)
        {
            var employeeToDelete = await context.EmployeeBiodatas.FindAsync(employee);
            if (employeeToDelete is null) throw new ArgumentNullException(nameof(employee));

            context.EmployeeBiodatas.Remove(employee);
        }

        public Task UpdateEmployee(EmployeeBiodata employee)
        {
            throw new NotImplementedException();
        }
    }
}