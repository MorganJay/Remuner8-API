using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.Dtos
{
    public class EmploymentTypeCreateDto
    {
        [Required]
        [Column("employmentName")]
        [StringLength(50)]
        public string EmploymentName { get; set; }
    }
}