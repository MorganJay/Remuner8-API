using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    [Table("Payslip")]
    public partial class Payslip
    {
        [Key]
        [Column("payslipId")]
        [StringLength(10)]
        public string PayslipId { get; set; }

        [Required]
        [Column("date")]
        [StringLength(50)]
        public string Date { get; set; }

        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }

        [Column("totalEarnings", TypeName = "decimal(19, 4)")]
        public decimal TotalEarnings { get; set; }

        [Column("totalDeductions", TypeName = "decimal(19, 4)")]
        public decimal TotalDeductions { get; set; }

        [Column("netSalary", TypeName = "decimal(19, 4)")]
        public decimal NetSalary { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.Payslips))]
        public virtual EmployeeBiodata Employee { get; set; }
    }
}