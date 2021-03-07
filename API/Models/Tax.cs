using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Index(nameof(EmployeeId), Name = "UQ__Taxes__C134C9C0AE6154C9", IsUnique = true)]
    public partial class Tax
    {
        public Tax()
        {
            Payslips = new HashSet<Payslip>();
        }

        [Key]
        [Column("taxId")]
        public int TaxId { get; set; }
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("PAYE", TypeName = "decimal(19, 4)")]
        public decimal? Paye { get; set; }
        [Column("pension", TypeName = "decimal(19, 4)")]
        public decimal? Pension { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.Tax))]
        public virtual EmployeeBiodata Employee { get; set; }
        [InverseProperty(nameof(Payslip.Tax))]
        public virtual ICollection<Payslip> Payslips { get; set; }
    }
}
