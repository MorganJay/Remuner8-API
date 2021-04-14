using System;

namespace API.Dtos
{
    public class PayrollDefaultReadDto
    {
        public DateTime MinimumSalaryPeriod { get; set; }
        public DateTime MaximumSalaryPeriod { get; set; }
        public int MaxWorkingDays { get; set; }
        public int MaxOvertimeHours { get; set; }
        public decimal MinTaxPercentage { get; set; }
        public decimal NonTaxableIncome { get; set; }
        public decimal FirstAnnualTaxableIncome { get; set; }
        public decimal SecondAnnualTaxableIncome { get; set; }
        public decimal ThirdAnnualTaxableIncome { get; set; }
        public decimal FourthAnnualTaxableIncome { get; set; }
        public decimal FifthAnnualTaxableIncome { get; set; }
        public decimal SixthAnnualTaxableIncome { get; set; }
        public string Tax { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}