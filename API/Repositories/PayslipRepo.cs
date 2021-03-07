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

        //public IEnumerable<Payslip> GetPayslipById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        EmployeeBiodata IPayslipRepository.GetPayslipById(string id)
        {
            _remuner8Context.EmployeeBiodatas.Include(s => s.EmployeeId).Include(s => s.StatutoryDeductions).Include(s => s.JobDescription).Include(s => s.Tax).ThenInclude(s => s.Pension).Include(s => s.Payslips).ThenInclude(s => s.TotalDeductions).Include(s => s.Tax).ThenInclude(s => s.Paye).Include(s => s.GrossSalary).Include(s => s.OtherAllowances).Include(s => s.Payslips);
        }
    }
}