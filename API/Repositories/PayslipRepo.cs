using System.Linq;
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
        EmployeeBiodata IPayslipRepository.GetPayslipById(string id)
        {
            var payslip = _remuner8Context.EmployeeBiodatas.Include(staff => staff.FirstName).Include(staff => staff.LastName)
                                                            .Include(staff => staff.GrossSalary).Include(staff => staff.OtherAllowances)
                                                            .Include(staff => staff.JobDescription).Include(staff => staff.Tax)
                                                            .Include(staff => staff.Payslips).Where(staff => staff.EmployeeId == id).FirstOrDefault();

            return payslip;
        }
    }
}