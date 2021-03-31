using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<EmployeeBiodata>> GetAllEmployeesAsync();

        Task<EmployeeBiodata> GetEmployeeByIdAsync(string id);

        Task CreateEmployeeAsync(EmployeeBiodata employee);

        Task UpdateEmployee(string id);

        Task DeleteEmployeeAsync(EmployeeBiodata employee);
    }
}