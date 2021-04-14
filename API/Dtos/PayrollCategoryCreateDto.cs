using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class PayrollCategoryCreateDto
    {
        [Required]
        [Column("categoryName")]
        [StringLength(30)]
        public string CategoryName { get; set; }
    }
}