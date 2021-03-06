using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollOvertimeItem
    {
        public PayrollOvertimeItem()
        {
            PayrollOvertimeItemsAssignments = new HashSet<PayrollOvertimeItemsAssignment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("rateid")]
        public int Rateid { get; set; }

        [ForeignKey(nameof(Rateid))]
        [InverseProperty(nameof(PayrollRate.PayrollOvertimeItems))]
        public virtual PayrollRate Rate { get; set; }
        [InverseProperty(nameof(PayrollOvertimeItemsAssignment.PayrollItem))]
        public virtual ICollection<PayrollOvertimeItemsAssignment> PayrollOvertimeItemsAssignments { get; set; }
    }
}
