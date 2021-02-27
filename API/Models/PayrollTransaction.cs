using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Index(nameof(EmployeeId), Name = "IX_PayrollTransactions_employeeId")]
    public partial class PayrollTransaction
    {
        [Key]
        [Column("transactionId")]
        public int TransactionId { get; set; }
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("transactionDateTime")]
        public DateTime TransactionDateTime { get; set; }
        [Column("deduction")]
        public bool Deduction { get; set; }
        [Column("principal", TypeName = "decimal(15, 2)")]
        public decimal Principal { get; set; }
        [Column("rate", TypeName = "decimal(3, 2)")]
        public decimal Rate { get; set; }
        [Column("balance", TypeName = "decimal(15, 2)")]
        public decimal Balance { get; set; }
        [Column("statutory")]
        public bool Statutory { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.PayrollTransactions))]
        public virtual EmployeeBiodata Employee { get; set; }
    }
}
