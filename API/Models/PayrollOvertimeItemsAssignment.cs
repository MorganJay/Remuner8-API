using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Keyless]
    [Table("PayrollOvertimeItemsAssignment")]
    public partial class PayrollOvertimeItemsAssignment
    {
        public int PayrollItemId { get; set; }
        [Required]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
    }
}
