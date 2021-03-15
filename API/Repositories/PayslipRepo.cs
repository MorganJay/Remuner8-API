using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class PayslipRepo : IPayslipRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public PayslipRepo(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async  Task <PayslipDto> GetPayslipByIdAsync(string id)
        {
            var payslip = await _remuner8Context.EmployeeBiodatas
                .Include(staff => staff.JobDescription)
                .Include(staff => staff.Tax)
                .Include(staff => staff.Payslips)
                .Where(staff => staff.EmployeeId == id).FirstOrDefaultAsync();

            var PayslipDto = new PayslipDto
            {
                FirstName = payslip.FirstName,
                LastName = payslip.LastName,
                OtherAllowances = payslip.OtherAllowances,
                Pension = payslip.Tax.Pension,
                Paye = payslip.Tax.Paye,
                JobDescriptionName = payslip.JobDescription.JobDescriptionName,
                BasicSalary = payslip.JobDescription.BasicSalary,
                HousingAllowances = payslip.JobDescription.HousingAllowance,
                payslip = payslip.Payslips ?? Enumerable.Empty<Payslip>(),
                

            };
           

            return PayslipDto;
        }
    }
}