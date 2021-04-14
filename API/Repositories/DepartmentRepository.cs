using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly Remuner8Context context;

        public DepartmentRepository(Remuner8Context context)
        {
            this.context = context;
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            if (department is null) throw new ArgumentNullException(nameof(department));

            await context.Departments.AddAsync(department);
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            if (department is null) throw new ArgumentNullException(nameof(department));
            var departmentToDelete = await context.Departments.FindAsync(department.DepartmentId);

            context.Departments.Remove(departmentToDelete);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<bool> DepartmentExists(string name)
        {
            var department = await context.Departments.FirstOrDefaultAsync(e => e.DepartmentName == name);
            return department is not null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        public Task UpdateDepartment(int id)
        {
            throw new NotImplementedException();
        }
    }
}