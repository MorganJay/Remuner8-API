using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data_Models.Dtos
{
    public class PayrollAdditionItemCreateDto
    {
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