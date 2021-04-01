using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class StatutoryDeduction
    {
        [Key]
        [Column("statutoryTypeId")]
        public int StatutoryTypeId { get; set; }
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("amount1", TypeName = "decimal(19, 4)")]
        public decimal Amount1 { get; set; }
        [Column("amount2", TypeName = "decimal(19, 4)")]
        public decimal Amount2 { get; set; }
        [Required]
        [Column("pfaCode")]
        [StringLength(10)]
        public string PfaCode { get; set; }
        [Required]
        [Column("pfaAccountNumber")]
        [StringLength(10)]
        public string PfaAccountNumber { get; set; }
        [Required]
        [Column("pfaAccountNumber1")]
        [StringLength(10)]
        public string PfaAccountNumber1 { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.StatutoryDeductions))]
        public virtual EmployeeBiodata Employee { get; set; }
        [ForeignKey(nameof(PfaCode))]
        [InverseProperty(nameof(PensionFundAdministration.StatutoryDeductions))]
        public virtual PensionFundAdministration PfaCodeNavigation { get; set; }
    }
}
