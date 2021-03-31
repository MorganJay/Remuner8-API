using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface IEmploymentTypeRepo
    {
        Task<IEnumerable<EmploymentType>> GetEmploymentTypeAsync();

        Task<EmploymentType> GetEmploymentTypeByIdAsync(int EmploymentTypeId);

        Task CreateEmploymentTypeAsync(EmploymentType employmentType);

        Task UpdateEmploymentTypeAsync(int EmploymentTypeId, EmploymentType employmentType);

        void DeleteEmploymentType(int EmploymentTypeId);

        Task<bool> SaveAsync();
    }
}