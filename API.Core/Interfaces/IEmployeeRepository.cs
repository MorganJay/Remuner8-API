using API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
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