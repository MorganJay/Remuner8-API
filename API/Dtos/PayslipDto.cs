using System;

namespace API.Dtos
{
    public class PayslipDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GrossSalary => BasicSalary + OtherAllowances + HousingAllowance + TransportAllowance;

        public decimal TotalDeduction => Pension + Paye;

        public decimal NetSalary => GrossSalary - TotalDeduction;

        public decimal OtherAllowances { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TransportAllowance { get; set; }
        public decimal Paye { get; set; }
        public decimal Pension { get; set; }
        public string PayslipId { get; set; }
        public string JobDescriptionName { get; set; }

        public DateTime DateJoined { get; set; }

        public string EmployeeId { get; set; }
    }
}