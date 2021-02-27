using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class EmployeeBiodata
    {
        public EmployeeBiodata()
        {
            PayrollTransactions = new HashSet<PayrollTransaction>();
            StatutoryDeductions = new HashSet<StatutoryDeduction>();
        }

        public string EmployeeId { get; set; }
        public byte[] Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string MaritalStatus { get; set; }
        public int DepartmentId { get; set; }
        public int JobDescriptionId { get; set; }
        public DateTime DateEmployed { get; set; }
        public decimal? OtherAllowances { get; set; }
        public decimal GrossSalary { get; set; }
        public string BankCode { get; set; }
        public string AccountNumber { get; set; }
        public int? PayrollAdditionItemId { get; set; }

        public virtual Bank BankCodeNavigation { get; set; }
        public virtual Department Department { get; set; }
        public virtual Password EmailAddressNavigation { get; set; }
        public virtual JobDescription JobDescription { get; set; }
        public virtual PayrollAdditionItem PayrollAdditionItem { get; set; }
        public virtual ICollection<PayrollTransaction> PayrollTransactions { get; set; }
        public virtual ICollection<StatutoryDeduction> StatutoryDeductions { get; set; }
    }
}
