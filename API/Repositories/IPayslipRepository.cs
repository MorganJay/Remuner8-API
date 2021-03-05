using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface IPayslipRepository
    {
        IEnumerable<Payslip>GetPayslipsById(string id);
    }
}
