using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dtos
{
    public class PayslipDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GrossSalary => JobDescription.BasicSalary + OtherAllowances + JobDescription.HousingAllowance;
        public decimal TotalDeduction()
        {
            return Tax.Pension + Tax.Paye + Tax.Loan
        }
        public decimal OtherAllowances { get; set; }
        public JobDescription JobDescription { get; set; }
        public Tax Tax { get; set; }
        public Payslip Payslip { get; set; }

    }
}
