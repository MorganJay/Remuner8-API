using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EmploymentTypeRepository : IEmploymentTypeRepo
    {
        private readonly Remuner8Context _remuner8Context;

        public EmploymentTypeRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateEmploymentTypeAsync(EmploymentType employmentType)
        {
            await _remuner8Context.EmploymentTypes.AddAsync(employmentType);
        }

        public void DeleteEmploymentType(int EmploymentTypeId)
        {
            var employeeType = _remuner8Context.EmploymentTypes.Find(EmploymentTypeId);
            if (employeeType is not null)
            {
                _remuner8Context.EmploymentTypes.Remove(employeeType);
            }
        }

        public async Task<IEnumerable<EmploymentType>> GetEmploymentTypeAsync()
        {
            return await _remuner8Context.EmploymentTypes.ToListAsync();
        }

        public async Task<EmploymentType> GetEmploymentTypeByIdAsync(int EmploymentTypeId)
        {
            return await _remuner8Context.EmploymentTypes.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }

        public Task UpdateEmploymentTypeAsync(int EmploymentTypeId, EmploymentType employmentType)
        {
            throw new NotImplementedException();
        }
    }
}