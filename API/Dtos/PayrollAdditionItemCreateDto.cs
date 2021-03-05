using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data_Models.Dtos
{
    public class PayrollAdditionItemCreateDto
    {
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

    }
}