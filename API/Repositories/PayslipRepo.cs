using System.Linq;
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

        public PayslipDto GetPayslipById(string id)
        {
            var payslip = _remuner8Context.EmployeeBiodatas.Include(staff => staff.JobDescription).Include(staff => staff.Tax).Include(staff => staff.Payslips).Where(staff => staff.EmployeeId == id).FirstOrDefault();

            var PayslipDto = new PayslipDto
            {
                FirstName = payslip.FirstName,
                LastName = payslip.LastName,
                OtherAllowances = payslip.OtherAllowances,
                Pension= payslip.Tax.Pension,
                Paye = payslip.Tax.Paye,
                JobDescriptionName = payslip.JobDescription.JobDescriptionName,
                BasicSalary = payslip.JobDescription.BasicSalary,
                HousingAllowances = payslip.JobDescription.HousingAllowance,
                
                

            };
            foreach (var item in payslip.Payslips)
            {
                item.

            }


            return PayslipDto;
        }
    }
}