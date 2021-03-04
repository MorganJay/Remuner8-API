using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
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
        [Column("taxId")]
        public int TaxId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.Payslips))]
        public virtual EmployeeBiodata Employee { get; set; }
        [ForeignKey(nameof(TaxId))]
        [InverseProperty("Payslips")]
        public virtual Tax Tax { get; set; }
    }
}
