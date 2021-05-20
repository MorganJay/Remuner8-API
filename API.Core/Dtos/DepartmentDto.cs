using System.ComponentModel.DataAnnotations;

namespace API.Core.Dtos
{
    public class DepartmentDto
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The department name must not exceed 50 characters")]
        public string DepartmentName { get; set; }
    }
}