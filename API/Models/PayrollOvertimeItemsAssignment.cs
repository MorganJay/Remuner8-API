using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PayrollOvertimeItemsAssignment")]
    public partial class PayrollOvertimeItemsAssignment
    {
        public int PayrollItemId { get; set; }
        [Required]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.PayrollOvertimeItemsAssignments))]
        public virtual EmployeeBiodata Employee { get; set; }
        [ForeignKey(nameof(PayrollItemId))]
        [InverseProperty(nameof(PayrollOvertimeItem.PayrollOvertimeItemsAssignments))]
        public virtual PayrollOvertimeItem PayrollItem { get; set; }
    }
}
