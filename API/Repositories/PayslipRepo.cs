using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PayslipRepo : IPayslipRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayslipRepo(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task<PayslipDto> GetPayslipByIdAsync(string id)
        {
            var employeeBiodata = await _remuner8Context.EmployeeBiodatas
              .Include(employee => employee.JobDescription)
              .Include(employee => employee.Tax)
              .Where(staff => staff.EmployeeId == id).FirstOrDefaultAsync();

            if (employeeBiodata is not null)
            {
                var PayslipDto = new PayslipDto
                {
                    FirstName = employeeBiodata.FirstName,
                    LastName = employeeBiodata.LastName,
                    JobDescriptionName = employeeBiodata.JobDescription.JobDescriptionName,
                    EmployeeId = employeeBiodata.EmployeeId,
                    DateJoined = employeeBiodata.DateEmployed,
                    BasicSalary = employeeBiodata.JobDescription.BasicSalary,
                    HousingAllowance = employeeBiodata.JobDescription.HousingAllowance,
                    TransportAllowance = employeeBiodata.JobDescription.TransportAllowance,
                    OtherAllowances = employeeBiodata.OtherAllowances,
                    Paye = employeeBiodata.Tax.Paye,
                    Pension = employeeBiodata.Tax.Pension
                };

                return PayslipDto;
            }
            throw new ArgumentNullException(nameof(id));
        }
    }
}