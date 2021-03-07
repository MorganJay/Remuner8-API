using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollTransaction
    {
        [Required]
        [Column("employeeId")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Key]
        [Column("transactionId")]
        public int TransactionId { get; set; }
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
