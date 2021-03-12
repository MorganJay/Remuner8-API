using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class PayrollAdditionItem
    {
        public PayrollAdditionItem()
        {
            PayrollAdditionItemsAssignments = new HashSet<PayrollAdditionItemsAssignment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("categoryId")]
        public int CategoryId { get; set; }

        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [Column("assigneeId")]
        public int AssigneeId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        [InverseProperty(nameof(AssigneeTable.PayrollAdditionItems))]
        public virtual AssigneeTable Assignee { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(PayrollCategory.PayrollAdditionItems))]
        public virtual PayrollCategory Category { get; set; }

        [InverseProperty(nameof(PayrollAdditionItemsAssignment.PayrollItem))]
        public virtual ICollection<PayrollAdditionItemsAssignment> PayrollAdditionItemsAssignments { get; set; }
    }
}