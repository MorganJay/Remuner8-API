using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class EmployeeBiodataCreateDto
    {
        [Key]
        [StringLength(10)]
        public string EmployeeId { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        [Required]
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("otherName")]
        [StringLength(50)]
        public string OtherName { get; set; }

        [Column("dateOfBirth", TypeName = "date")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column("address")]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [Column("phoneNumber")]
        [StringLength(20, MinimumLength = 11, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("emailAddress")]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [Column("gender")]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required]
        [Column("countryName")]
        [StringLength(30)]
        public string CountryName { get; set; }

        [Required]
        [Column("stateName")]
        [StringLength(30)]
        public string StateName { get; set; }

        [Required]
        [Column("maritalStatus")]
        [StringLength(12)]
        public string MaritalStatus { get; set; }

        [Column("departmentId")]
        public int DepartmentId { get; set; }

        [Column("jobDescriptionId")]
        public int JobDescriptionId { get; set; }

        [Column("dateEmployed", TypeName = "date")]
        public DateTime DateEmployed { get; set; }

        [Column("otherAllowances", TypeName = "decimal(19, 4)")]
        public decimal OtherAllowances { get; set; }

        [Column("grossSalary", TypeName = "decimal(19, 4)")]
        public decimal GrossSalary { get; set; }

        [Required]
        [Column("bankName")]
        [StringLength(150)]
        public string BankName { get; set; }

        [Required]
        [Column("accountNumber")]
        [StringLength(10)]
        public string AccountNumber { get; set; }
    }
}