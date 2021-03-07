using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    [Table("AssigneeTable")]
    public partial class AssigneeTable
    {
        public AssigneeTable()
        {
            PayrollAdditionItems = new HashSet<PayrollAdditionItem>();
            PayrollDeductionItems = new HashSet<PayrollDeductionItem>();
        }

        [Key]
        [Column("assigneeid")]
        public int Assigneeid { get; set; }
        [Required]
        [Column("assigneeName")]
        [StringLength(50)]
        public string AssigneeName { get; set; }

        [InverseProperty(nameof(PayrollAdditionItem.Assignee))]
        public virtual ICollection<PayrollAdditionItem> PayrollAdditionItems { get; set; }
        [InverseProperty(nameof(PayrollDeductionItem.Assignee))]
        public virtual ICollection<PayrollDeductionItem> PayrollDeductionItems { get; set; }
    }
}
