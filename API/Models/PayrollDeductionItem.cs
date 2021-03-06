using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollDeductionItem
    {
        public PayrollDeductionItem()
        {
            PayrollDeductionItemsAssignments = new HashSet<PayrollDeductionItemsAssignment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        [Column("assigneeId")]
        public int AssigneeId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        [InverseProperty(nameof(AssigneeTable.PayrollDeductionItems))]
        public virtual AssigneeTable Assignee { get; set; }
        [InverseProperty(nameof(PayrollDeductionItemsAssignment.PayrollItem))]
        public virtual ICollection<PayrollDeductionItemsAssignment> PayrollDeductionItemsAssignments { get; set; }
    }
}
