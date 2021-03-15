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
        public decimal GrossSalary => BasicSalary + OtherAllowances + HousingAllowances;
        public decimal TotalDeduction()
        {
            return Pension + Paye;
        }
        public decimal OtherAllowances { get; set; }
        public decimal HousingAllowances { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Paye { get; set; }
        public decimal Pension { get; set; }
        public string Payslip { get; set; }
        public string JobDescriptionName { get; set; }
        public IEnumerable<Payslip> payslip { get; set; }
    }
}
