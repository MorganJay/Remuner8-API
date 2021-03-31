using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IDepartmentRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentByIdAsync(int id);

        Task<bool> DepartmentExists(string name);

        Task CreateDepartmentAsync(Department department);

        Task UpdateDepartment(int id);

        Task DeleteDepartmentAsync(Department department);
    }
}