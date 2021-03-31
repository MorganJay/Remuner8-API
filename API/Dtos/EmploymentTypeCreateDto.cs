using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmploymentTypeCreateDto
    {
        [Key]
        [Column("employmentTypeId")]
        public int EmploymentTypeId { get; set; }
        [Required]
        [Column("employmentName")]
        [StringLength(50)]
        public string EmploymentName { get; set; }
    }
}
