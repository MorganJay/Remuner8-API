using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("PayrollAdditionItemsAssignment")]
    public partial class PayrollAdditionItemsAssignment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int PayrollItemId { get; set; }
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeBiodata.PayrollAdditionItemsAssignments))]
        public virtual EmployeeBiodata Employee { get; set; }
        [ForeignKey(nameof(PayrollItemId))]
        //[InverseProperty(nameof(PayrollAdditionItem.PayrollAdditionItemsAssignments))]
        public virtual PayrollAdditionItem PayrollItem { get; set; }
    }
}
