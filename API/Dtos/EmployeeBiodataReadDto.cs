using System;

namespace API.Dtos
{
    public class EmployeeBiodataReadDto
    {
        public string EmployeeId { get; set; }
        public string Avatar { get; set; }

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

        public string DepartmentName { get; set; }

        public string JobDescriptionName { get; set; }

        public DateTime DateEmployed { get; set; }

        public decimal OtherAllowances { get; set; }

        public decimal GrossSalary { get; set; }

        public string BankName { get; set; }

        public string AccountNumber { get; set; }
    }
}