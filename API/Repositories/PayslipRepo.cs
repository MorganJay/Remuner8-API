using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public class PayslipRepo : IPayslipRepository
    {
        public IEnumerable<Payslip> GetPayslipsById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
