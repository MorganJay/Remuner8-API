using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class EmploymentTypeReadDto
    {
        [Column("employmentTypeId")]
        public int EmploymentTypeId { get; set; }

        [Column("employmentName")]
        public string EmploymentName { get; set; }
    }
}