using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IDepartmentRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Departments>> GetAllDepartmentsAsync();

        Task<Departments> GetDepartmentByIdAsync(int id);

        Task<bool> DepartmentExists(string name);

        Task CreateDepartmentAsync(Departments department);

        Task UpdateDepartment(Departments department);

        Task DeleteDepartmentAsync(Departments department);
    }
}