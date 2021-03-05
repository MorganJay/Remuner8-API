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
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("categoryId")]
        public int? CategoryId { get; set; }

        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }

        [Column("assigneeId")]
        public int AssigneeId { get; set; }
    }
}