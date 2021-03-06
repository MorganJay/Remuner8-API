using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Index(nameof(Assigneeid), Name = "IX_PayrollAdditionItems_AssigneeTableAssigneeid")]
    [Index(nameof(CategoryId), Name = "IX_PayrollAdditionItems_PayrollCategoryCategoryId")]
    public partial class PayrollAdditionItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        public int Assigneeid { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Assigneeid))]
        [InverseProperty(nameof(AssigneeTable.PayrollAdditionItems))]
        public virtual AssigneeTable Assignee { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(PayrollCategory.PayrollAdditionItems))]
        public virtual PayrollCategory PayrollCategoryCategory { get; set; }
    }
}
