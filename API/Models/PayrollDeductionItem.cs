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
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        [Column("assigneeId")]
        public int AssigneeId { get; set; }
    }
}
