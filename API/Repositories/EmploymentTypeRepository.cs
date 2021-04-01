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

        public void DeleteEmploymentType(int id)
        {
            var EmploymentTypeId = _remuner8Context.EmploymentTypes.Find(id);

            if (EmploymentTypeId is null)
            {
                throw new ArgumentNullException(nameof(EmploymentTypeId));
            }
            _remuner8Context.EmploymentTypes.Remove(EmploymentTypeId);
        }

        public async Task<IEnumerable<EmploymentType>> GetEmploymentTypeAsync()
        {
            return await _remuner8Context.EmploymentTypes.ToListAsync();
        }

        public async Task<EmploymentType> GetEmploymentTypeByIdAsync(int id)
        {
            return await _remuner8Context.EmploymentTypes.Where(s => s.EmploymentTypeId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }

        public void UpdateEmploymentTypeAsync(int id, EmploymentType employmentType)
        {
        }
    }
}