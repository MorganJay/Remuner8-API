using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> SaveChanges();

        Task<int> EmployeeCountAsync();

        Task<IEnumerable<EmployeeBiodata>> GetAllEmployeesAsync();

        //Task<EmployeeBiodata> GetEmployeeByIdAs(string id);

        //Task CreateEmployeeAsync(EmployeeBiodata employee);
    }
}